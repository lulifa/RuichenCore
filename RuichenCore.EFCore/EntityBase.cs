using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using RuichenCore.Common;

namespace RuichenCore.EFCore
{
    public abstract class EntityBase<TKey> : IEntity<TKey>
    {
        public EntityBase()
        {
            if (typeof(TKey) == typeof(Guid))
            {
                Id = Guid.NewGuid().CastTo<TKey>();
            }
        }
        public TKey Id { get; set; }
    }
}
