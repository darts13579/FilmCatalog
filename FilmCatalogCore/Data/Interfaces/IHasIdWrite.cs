namespace FilmCatalogCore.Data.Interfaces
{
    public interface IHasIdWrite : IHasIdWrite<int> {}

    /*[TsInterface(Name = nameof(IHasIdWrite) + "Generic")]*/
    public interface IHasIdWrite<in T>
    {
        T Id { set; }
    }
}