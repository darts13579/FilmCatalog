namespace FilmCatalogCore.Models
{
    public class FilmEditModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public string Producer { get; set; }

        public int Year { get; set; }

        public string PosterUrl { get; set; }
    }
}