namespace FilmCatalogCore.Data.Interfaces
{
    public interface IHasIdRead : IHasIdRead<int> {}

    /*[TsInterface(Name = nameof(IHasIdRead) + "Generic")]*/
    public interface IHasIdRead<out T>
    {
        T Id { get; }
    }
}