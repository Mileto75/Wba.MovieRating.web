using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.MovieRating.Core.Entities
{
    public class Actor : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<MovieActor> Movies { get; set; }
    }
}
