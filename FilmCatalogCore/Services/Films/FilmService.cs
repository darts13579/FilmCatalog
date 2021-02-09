using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FilmCatalogCore.Data;
using FilmCatalogCore.Data.Entities;
using FilmCatalogCore.Extensions;
using FilmCatalogCore.Models;
using FilmCatalogCore.Services.Posters;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FilmCatalogCore.Services.Films
{
    public class FilmService : IFilmService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPosterService _posterService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public FilmService(ApplicationDbContext dbContext, IPosterService posterService, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _posterService = posterService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
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
                Author = _.User.UserName,
                PosterUrl = _.Poster.Path
            }).ToList();
            
            return films;
        }

        public async Task<FilmViewDetailModel> GetById(int id)
        {
            var userName = _httpContextAccessor.HttpContext.User.GetLoggedInUserName();
            var dbFilm = await _dbContext.Films.FindAsync(id);
            
            var film = new FilmViewDetailModel
            {
                    Id = dbFilm.Id,
                    Name = dbFilm.Name,
                    Description = dbFilm.Description,
                    Producer = dbFilm.Producer,
                    Year = dbFilm.Year,
                    Author = dbFilm.User.UserName,
                    PosterUrl = dbFilm.Poster.Path,
                    CanEdit = userName == dbFilm.User.UserName
            }; 

            return film;
        }

        public async Task<FilmEditModel> GetEditFilm(int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            var dbFilm = await _dbContext.Films.FindAsync(id);
            if (userId != dbFilm.UserId)
                return null;
            
            var film = new FilmEditModel
            {
                Id = dbFilm.Id,
                Name = dbFilm.Name,
                Description = dbFilm.Description,
                Producer = dbFilm.Producer,
                Year = dbFilm.Year,
            }; 

            return film;
        }

        public async Task<FilmEditModel> EditFilm(FilmEditModel model)
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

        /*TODO: return type*/
        public async Task Delete(int id)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            var dbFilm = await _dbContext.Films.FindAsync(id);
            if (userId != dbFilm.UserId)
                return;

            _dbContext.Films.Remove(dbFilm);
            
            
            await _dbContext.SaveChangesAsync();
            
            return;
        }

        public async Task Create(FilmCreateModel film)
        {
            var userId = _httpContextAccessor.HttpContext.User.GetLoggedInUserId<string>();
            var user = _userManager.Users.First(_ => _.Id == userId);
            
            var poster = await _posterService.AddPoster(film.Image);
            
            var newFilm = new Film
            {
                Description = film.Description,
                Name = film.Name,
                Year = film.Year,
                Producer = film.Producer,
                User = user,
                Poster = poster
            };
            _dbContext.Add(newFilm);
            
            await _dbContext.SaveChangesAsync();
        }
    }
}