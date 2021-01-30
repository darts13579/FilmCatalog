using System.Diagnostics.CodeAnalysis;
using FilmCatalogCore.Data.Entities;
using FilmCatalogCore.Data.Interfaces;

namespace FilmCatalogCore.Data.Base
{
  public abstract class EntityBaseWithUser : EntityBase, IHasUser
  {
    [NotNull]
    [SuppressMessage("ReSharper", "NotNullMemberIsNotInitialized", Justification = "EF")]
    public string UserId { get; set; }

    [NotNull]
    [SuppressMessage("ReSharper", "VirtualMemberNeverOverridden.Global", Justification = "EF Lazy Loading")]
    public virtual User User { get; set; }
  }
}