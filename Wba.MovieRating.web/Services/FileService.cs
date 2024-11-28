
using Wba.MovieRating.Web.Areas.Admin.ViewModels;
using Wba.MovieRating.web.Models;
using Wba.MovieRating.Web.Services.Models;
using Wba.MovieRating.Web.Services.Interfaces;

namespace Wba.MovieRating.Web.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public bool DeleteFile(string path)
        {
            //delete file here
            //check if file exists 
            //try catch for exception
            if (!File.Exists(path))
            {
                return false;
            }
            try
            {
                File.Delete(path);
                return true;
            }
            catch (UnauthorizedAccessException unauthorizedAccessException)
            {
                Console.WriteLine(unauthorizedAccessException.Message);
                return false;
            }
        }

        public async Task<ResultModel> StoreFileAsync(IFormFile file)
        {
            //create unique filename
            var filename = $"{Guid.NewGuid()}_{file.FileName}";
            //create folder
            var folderToImages = Path.Combine(_webHostEnvironment.WebRootPath,
                "images");
            if (!Directory.Exists(folderToImages))
            {
                try
                {
                    Directory.CreateDirectory(folderToImages);
                }
                catch (UnauthorizedAccessException unauthorizedAccessException)
                {
                    Console.WriteLine(unauthorizedAccessException.Message);
                    return new ResultModel
                    {
                        IsSuccess = false,
                        Error = "Something went wrong with the file upload"
                    };
                }
            }
            //create fullpath
            var fullpath = Path.Combine(folderToImages, filename);
            //copy to path
            try
            {
                using (FileStream fileStream = new FileStream(fullpath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            catch (IOException iOexception)
            {
                Console.WriteLine(iOexception.Message);
                return new ResultModel
                {
                    IsSuccess = false,
                    Error = "Something went wrong with the file upload"
                };
            }
            return new ResultModel
            {
                IsSuccess = true,
                Result = filename
            }; ;
        }
    }
}
