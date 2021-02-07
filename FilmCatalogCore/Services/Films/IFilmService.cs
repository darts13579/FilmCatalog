using System.Collections.Generic;
using System.Threading.Tasks;
using FilmCatalogCore.Models;
using JetBrains.Annotations;

namespace FilmCatalogCore.Services.Films
{
    public interface IFilmService
    {
        Task<List<FilmViewModel>> GetFilmList();
        Task<object> GetById(int id);
        Task<object> EditFilm(FilmEditModel model);
        Task<object> Delete(int id);
        Task Create(FilmCreateModel film, [CanBeNull] string userName);
    }
}