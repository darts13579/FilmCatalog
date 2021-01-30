using System;

namespace FilmCatalogCore.Data.Interfaces
{
    public interface IEntityBase<TKey> : IEntity, IHasId<TKey>
        where TKey : struct, IEquatable<TKey> {}
}