﻿namespace Wba.MovieRating.Web.ViewModels
{
    public class MoviesInfoViewModel : MovieBaseViewModel
    {
        public BaseViewModel Company { get; set; }
        public IEnumerable<BaseViewModel> Directors { get; set; }
        public IEnumerable<BaseViewModel> Actors { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
