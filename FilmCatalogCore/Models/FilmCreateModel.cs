using Microsoft.AspNetCore.Http;

namespace FilmCatalogCore.Models
{
    public class FilmCreateModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Producer { get; set; }

        public int Year { get; set; }

        public IFormFile Image { get; set; }
    }
}