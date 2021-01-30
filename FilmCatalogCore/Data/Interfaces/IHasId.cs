namespace FilmCatalogCore.Data.Interfaces
{
    public interface IHasId : IHasId<int>, IHasIdRead, IHasIdWrite {}

    /*[TsInterface(Name = nameof(IHasId) + "Generic")]*/
    public interface IHasId<T> : IHasIdRead<T>, IHasIdWrite<T>
    {
        new T Id { get; set; }
    }
}