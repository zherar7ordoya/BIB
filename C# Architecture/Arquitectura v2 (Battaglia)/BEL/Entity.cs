using System;

using TCTD2020.ArquitecturaCapasV2.Interfaces;

namespace TCTD2020.ArquitecturaCapasV2.BE
{
    public abstract class Entity : IEntity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get;  }
    }
}
