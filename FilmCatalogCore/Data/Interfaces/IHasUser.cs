using FilmCatalogCore.Data.Entities;
using JetBrains.Annotations;

namespace FilmCatalogCore.Data.Interfaces
{
  public interface IHasUser : IHasUserId
  {
    [NotNull]
    public User User { get; set; }
  }
}