using EntityComponent.Components;

namespace EntityComponent.Entities
{
    public interface IEntity : IUpdatable, IDrawable
    {
        int ID { get; }
        int ParentID { get; }

        TType GetComponent<TType>() where TType : class;

        IEntity AddComponent(IComponent component);
        IEntity RemoveComponent(IComponent component);
    }
}