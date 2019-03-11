using NUnit.Framework;
using EntityComponent.Entities;
using EntityComponent.Tests.Components;

namespace EntityComponent.Tests
{
    public class Tests
    {
        private Entity _entity;

        [SetUp]
        public void Setup()
        {
            _entity = new Entity();
        }

        [Test]
        public void AddComponentsToEntity()
        {
            _entity.AddComponent(new PlayerComponent(_entity))
                   .AddComponent(new MaterialComponent(_entity));

            Assert.That(_entity.GameComponentCount, Is.EqualTo(2));
            Assert.That(_entity.DrawableGameComponentCount, Is.EqualTo(1));
        }

        [Test]
        public void RemoveComponentsFromEntity()
        {
            _entity.AddComponent(new PlayerComponent(_entity))
                   .AddComponent(new MaterialComponent(_entity));

            var playerComponent = _entity.GetComponent<PlayerComponent>();
            var materialComponent = _entity.GetComponent<MaterialComponent>();

            _entity.RemoveComponent(playerComponent)
                   .RemoveComponent(materialComponent);

            Assert.That(_entity.GameComponentCount, Is.EqualTo(0));
            Assert.That(_entity.DrawableGameComponentCount, Is.EqualTo(0));
        }

        [Test]
        public void GetComponentFromEntity()
        {
            var somePlayerComponent = new PlayerComponent(_entity);
            var someMaterialComponent = new MaterialComponent(_entity);

            _entity.AddComponent(somePlayerComponent)
                   .AddComponent(someMaterialComponent);

            var samePlayerComponent = _entity.GetComponent<PlayerComponent>();
            var sameMaterialComponent = _entity.GetComponent<MaterialComponent>();

            Assert.That(Has.ReferenceEquals(somePlayerComponent, 
                                            samePlayerComponent));
            Assert.That(Has.ReferenceEquals(someMaterialComponent,
                                            sameMaterialComponent));
        }

        [Test]
        public void EnityComponentIDEquivalence()
        {
            _entity.AddComponent(new PlayerComponent(_entity))
                   .AddComponent(new MaterialComponent(_entity));

            var playerComponent = _entity.GetComponent<PlayerComponent>();
            var materialComponent = _entity.GetComponent<MaterialComponent>();

            Assert.That(_entity.ID, Is.EqualTo(playerComponent.Entity.ID));
            Assert.That(_entity.ID, Is.EqualTo(materialComponent.Entity.ID));
        }
    }
}