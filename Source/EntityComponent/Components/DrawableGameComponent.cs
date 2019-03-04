using EntityComponent.Entities;
using EntityComponent.Renderers;

namespace EntityComponent.Components
{
    public abstract class DrawableGameComponent : GameComponent, IDrawableComponent
    {
        public DrawableGameComponent(IEntity entity) : base(entity) { }

        public abstract void Render(IRenderer renderer);
    }
}