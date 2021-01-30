using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FilmCatalogCore.Data.Interfaces;
using JetBrains.Annotations;

namespace FilmCatalogCore.Data.Base
{
    [PublicAPI]
    public abstract class EntityBase : EntityBase<int> {}

    [PublicAPI]
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }
    }
}