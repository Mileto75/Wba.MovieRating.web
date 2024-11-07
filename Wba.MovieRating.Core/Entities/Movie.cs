using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.MovieRating.Core.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        //one to many company
        public Company Company { get; set; }
        //unshadowed 
        public int CompanyId { get; set; }
        //ratings
        public ICollection<Rating> Ratings { get; set; }
        //director
        //by convention many to many
        public ICollection<Director> Directors { get; set; }
        public ICollection<MovieActor> Actors { get; set; }
    }
}
