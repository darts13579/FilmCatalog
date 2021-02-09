using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using FilmCatalogCore.Data;
using FilmCatalogCore.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FilmCatalogCore.Services.Posters
{
    public class PosterService : IPosterService
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly IWebHostEnvironment _appEnvironment;

        public PosterService(ApplicationDbContext dbContext, IWebHostEnvironment appEnvironment)
        {
            _dbContext = dbContext;
            _appEnvironment = appEnvironment;
        }

        public async Task<Poster> AddPoster(IFormFile file)
        {
            try
            {
                var id = Guid.NewGuid();
            
                var path = "/Files/" + id + file.ContentType.Replace("image/", ".");
            
                await using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var poster = new Poster {Name = file.FileName, Path = path};

                await _dbContext.Posters.AddAsync(poster);

                await _dbContext.SaveChangesAsync();
                
                return poster;
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to create new image, stack: {e}");
                throw;
            }
        }
        
        public async Task RemovePoster(Poster poster)
        {
            try
            {
                File.Delete(poster.Path);
                
                _dbContext.Posters.Remove(poster);

                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Failed to delete image, stack: {e}");
                throw;
            }
        }
    }
}