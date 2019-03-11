using EntityComponent.Entities;
using System;

namespace EntityComponent.Components
{
    public interface IComponent
    {
        IEntity Entity { get; }

        void Initialize();
    }
}