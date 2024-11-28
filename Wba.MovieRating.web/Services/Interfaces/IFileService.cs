using Wba.MovieRating.Web.Services.Models;

namespace Wba.MovieRating.Web.Services.Interfaces
{
    public interface IFileService
    {
        Task<ResultModel> StoreFileAsync(IFormFile file);
        bool DeleteFile(string path);
    }
}
