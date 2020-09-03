using System;

namespace RuichenCore.EFCore
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
