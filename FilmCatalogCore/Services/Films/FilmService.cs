using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmCatalogCore.Data;
using FilmCatalogCore.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmCatalogCore.Services.Films
{
    public class FilmService : IFilmService
    {
        private readonly ApplicationDbContext _dbContext;

        public FilmService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        //TODO: filters
        public async Task<List<FilmViewModel>> GetFilmList()
        {
            var films = _dbContext.Films.ToList().Select(_ => new FilmViewModel()
            {
                Name = _.Name,
                Description = _.Description,
                Producer = _.Producer,
                Year = _.Year,
                Poster = _.Poster,
            }).ToList();
            
            return films;
        }
    }
}