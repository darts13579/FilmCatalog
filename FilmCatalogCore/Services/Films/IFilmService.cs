using System.Collections.Generic;
using System.Threading.Tasks;
using FilmCatalogCore.Models;

namespace FilmCatalogCore.Services.Films
{
    public interface IFilmService
    {
        Task<List<FilmViewModel>> GetFilmList();
    }
}