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
    }
}
