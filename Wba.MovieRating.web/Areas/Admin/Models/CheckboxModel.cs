using Microsoft.AspNetCore.Mvc;

namespace Wba.MovieRating.Web.Areas.Admin.Models
{
    public class CheckboxModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [HiddenInput]
        public string Value { get; set; }
        public bool IsChecked { get; set; }
    }
}
