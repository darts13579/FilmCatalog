using System.Diagnostics.CodeAnalysis;
using FilmCatalogCore.Data.Entities;

namespace FilmCatalogCore.Models
{
    public class FilmViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string Producer { get; set; }

        public int Year { get; set; }

        public string PosterUrl { get; set; }

        public string Author { get; set; }
    }
}