USE GradSchool
GO
--vraag1
ALTER TABLE students
ADD email varchar(100)
SELECT * FROM Students
GO
CREATE OR ALTER PROCEDURE spFillEmail
AS
SET NOCOUNT ON
	--update the students table
	UPDATE Students
	SET email = 
	REPLACE( REPLACE(firstname+'.'+lastname+'@student.howest.be',
	' ','.'),'''','')
GO
exec spFillEmail
SELECT * FROM Students
--vraag 2
ALTER TABLE Students
ADD penalty int
GO
CREATE OR ALTER PROCEDURE spFillPenalty
AS
SET NOCOUNT ON
	--set penalty = 0
	UPDATE Students
	SET penalty = 0
	--set penalty 50
	UPDATE Students
	SET penalty = 50
	FROM Students as s
	WHERE YEAR(GETDATE()) - YEAR(dateOfBirth) >= 18
	AND paid = 0
	AND (SELECT COUNT(courseId) FROM StudentsCourses as sc
	WHERE sc.studentId = s.studentId) >= 2
GO
exec spFillPenalty
SELECT * FROM Students
--
GO
CREATE OR ALTER PROCEDURE spPay
@studentId int
AS
SET NOCOUNT ON
--declare @toPay
DECLARE @toPay int
--get the sum of fees using @studentId
	--join students => studentsCourses => courses
SELECT @toPay = SUM(c.fee) FROM StudentsCourses as sc
JOIN Courses as c
ON sc.courseId = c.courseId
WHERE sc.studentId = @studentId
--update students set paid = @toPay for @studentId
-- set penalty = 0
UPDATE Students
SET paid = @toPay,penalty = 0
WHERE studentId = @studentId
GO
exec spPay 1
SELECT * FROM Students WHERE studentId = 1


--functions
--Schrijf een functie die het aantal inschrijvingen 
--van een student teruggeeft
GO
CREATE OR ALTER FUNCTION fCountRegistrations(@studentId int)
RETURNS int
AS
BEGIN
	DECLARE @numOfCourses int = 0
	SELECT @numOfCourses = COUNT(studentId)
	FROM StudentsCourses
	WHERE studentId = @studentId
	RETURN @numOfCourses
END
GO
SELECT COUNT(studentId)
FROM StudentsCourses
WHERE studentId = 1

SELECT dbo.fCountRegistrations(2) as nomOfregistrations
--use it in query
SELECT *, dbo.fCountRegistrations(s.studentId) as numOfRegistrations
FROM Students As s
--Toon de studenten die meer dan eenbepaald bedrag betaald hebben
--table valued function
GO
CREATE OR ALTER FUNCTION fShowStudentsPaid(@amount int)
RETURNS TABLE
AS
	RETURN(SELECT * FROM Students as s
			WHERE paid > @amount)
GO
SELECT *,c.courseName FROM dbo.fShowStudentsPaid(200) AS sp
JOIN StudentsCourses sc
ON sc.studentId = sp.studentId
JOIN Courses as c
on sc.courseId = c.courseId

