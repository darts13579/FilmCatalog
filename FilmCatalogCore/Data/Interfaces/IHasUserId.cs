namespace FilmCatalogCore.Data.Interfaces
{
  public interface IHasUserId
  {
    [JetBrains.Annotations.NotNull]
    public string UserId { get; set; }
  }
}