using EntityComponent.Components;
using EntityComponent.Entities;
using EntityComponent.Renderers;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityComponent.Tests.Components
{
    public class MaterialComponent : DrawableGameComponent
    {
        public MaterialComponent(IEntity entity) : base(entity) { }

        public override void Initialize()
        {
            // Dummy
        }

        public override void Update(float deltaTime)
        {
            // Dummy
        }

        public override void Render(IRenderer renderer)
        {
            // Dummy
        }


    }
}
