using EntityComponent.Components;
using EntityComponent.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityComponent.Tests.Components
{
    public class PlayerComponent : GameComponent
    {
        public PlayerComponent(IEntity entity) : base(entity)
        {
            // Dummy
        }


        public override void Initialize()
        {
            // Dummy
        }

        public override void Update(float deltaTime)
        {
            // Dummy
        }
    }
}
