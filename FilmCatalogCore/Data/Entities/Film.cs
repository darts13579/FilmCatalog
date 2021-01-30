using FilmCatalogCore.Data.Base;

namespace FilmCatalogCore.Data.Entities
{
    public class Film : EntityBaseWithUser
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Producer { get; set; }

        public int Year { get; set; }

        public int PosterId { get; set; }
    }
}