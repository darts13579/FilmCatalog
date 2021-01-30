using System.Diagnostics.CodeAnalysis;
using FilmCatalogCore.Data.Entities;

namespace FilmCatalogCore.Models
{
    public class FilmViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Producer { get; set; }

        public int Year { get; set; }

        public int PosterId { get; set; }

        [NotNull]
        [SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global", Justification = "EF Lazy Loading")]
        public virtual Poster Poster { get; set; }
    }
}