using System.Threading.Tasks;
using FilmCatalogCore.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace FilmCatalogCore.Services.Posters
{
    public interface IPosterService
    {
        Task<Poster> AddPoster(IFormFile file);
    }
}