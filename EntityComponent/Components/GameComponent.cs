using System;
using System.Collections.Generic;
using System.Text;
using EntityComponent.Entities;

namespace EntityComponent.Components
{
    public abstract class GameComponent : IUpdatableComponent
    {
        private IEntity _entity;
        public IEntity Entity => _entity;

        protected GameComponent(IEntity entity)
        {
            _entity = entity;
        }

        public abstract void Initialize();
        public abstract void Update(float deltaTime);
    }
}
