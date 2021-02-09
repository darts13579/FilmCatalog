using System.Collections.Generic;

namespace FilmCatalogCore.Models
{
    public class IndexViewModel
    {
        public IEnumerable<FilmViewModel> Films { get; set; }

        public PaginationModel Pagination { get; set; }
    }
}