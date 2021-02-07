using System.Collections.Generic;
using System.Threading.Tasks;
using FilmCatalogCore.Models;
using JetBrains.Annotations;

namespace FilmCatalogCore.Services.Films
{
    public interface IFilmService
    {
        Task<List<FilmViewModel>> GetFilmList();
        Task<FilmViewDetailModel> GetById(int id, string userName);
        Task<object> EditFilm(FilmEditModel model);
        Task<object> Delete(int id);
        Task Create(FilmCreateModel film, [CanBeNull] string userName);
    }
}