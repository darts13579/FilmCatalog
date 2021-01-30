using FilmCatalogCore.Data.Base;

namespace FilmCatalogCore.Data.Entities
{
    public class Poster : EntityBase
    {
        public string Name { get; set; }
        
        public string Path { get; set; }
    }
}