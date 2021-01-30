using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var films = _dbContext.Films.ToList().Select(_ => new FilmViewModel
            {
                Id = _.Id,
                Name = _.Name,
                Description = _.Description,
                Producer = _.Producer,
                Year = _.Year,
                //TODO: poster url
            }).ToList();
            
            return films;
        }

        public async Task<object> GetById(int id)
        {
            var film = await _dbContext.Films.FindAsync(id);

            return film;
        }

        public async Task<object> EditFilm(FilmEditModel model)
        {
            var film = await _dbContext.Films.FindAsync(model.Id);

            film.Name = model.Name;
            film.Description = model.Description;
            film.Producer = model.Producer;
            film.Year = model.Year;

            try
            {
                film.Name = model.Name;
                film.Description = model.Description;
                film.Producer = model.Producer;
                film.Year = model.Year;

                await _dbContext.SaveChangesAsync();

                return model;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to edit item. Error stack: {e}");
                throw;
            }
            
        }

        public Task<object> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}