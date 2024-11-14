using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.MovieRating.Core.Entities
{
    public class Rating : BaseEntity
    {
        public int Score { get; set; }
        public string Review { get; set; }
        //movie
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        //user
        public User User { get; set; }
        public int UserId { get; set; }
    }
}