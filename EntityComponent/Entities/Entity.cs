using EntityComponent.Components;
using EntityComponent.Entities;
using EntityComponent.Renderers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntityComponent
{
    /// <summary>
    /// Сущность - некоторый объект на сцене, хранящий в себе компоненты
    /// </summary>
    public class Entity : IEntity
    {
        private int _id;
        public int ID => _id;

        private int _parentID;
        public int ParentID => _parentID;

        public int GameComponentCount => _updatableComponents.Count;
        public int DrawableGameComponentCount => _drawableComponents.Count;

        private List<IUpdatableComponent> _updatableComponents;
        private List<IDrawableComponent> _drawableComponents;

        public Entity()
        {
            _updatableComponents = new List<IUpdatableComponent>();
            _drawableComponents = new List<IDrawableComponent>();
        }

        /// <summary>
        /// Добавить компонент сущности
        /// </summary>
        /// <remarks>
        /// Если компонент является отрисовычным, то он разделяется на два списка:
        /// Обновляемый и отрисовочный.
        /// Данный подход предполагает кэширование, а не проверку на допустимый тип в момент обновления или отрисовки
        /// </remarks>
        /// <param name="component"></param>
        public IEntity AddComponent(IComponent component)
        {
            switch (component)
            {
                case DrawableGameComponent dgc:
                    _drawableComponents.Add(dgc);
                    _updatableComponents.Add(dgc);
                    break;
                case GameComponent gc:
                    _updatableComponents.Add(gc);
                    break;
                default:
                    throw new ArgumentException("Unkown component type!", component.ToString());
            }

            return this;
        }

        /// <summary>
        /// Добавить компонент сущности
        /// </summary>
        /// <remarks>
        /// Если компонент является отрисовычным, то он удаляет компонент из двух списков:
        /// Обновляемый и отрисовочный.
        /// </remarks>
        /// <param name="component"></param>
        public IEntity RemoveComponent(IComponent component)
        {
            switch (component)
            {
                case DrawableGameComponent dgc:
                    _updatableComponents.Remove(dgc);
                    _drawableComponents.Remove(dgc);
                    break;
                case GameComponent gc:
                    _updatableComponents.Remove(gc);
                    break;
                default:
                    throw new ArgumentException("Unkown component type!", component.ToString()); ;
            }

            return this;
        }

        /// <summary>
        /// Получить компонент
        /// </summary>
        /// <typeparam name="TType">Тип компонента</typeparam>
        /// <param name="type">Тип компонента</param>
        /// <returns></returns>
        public TType GetComponent<TType>() where TType : class
        {
            foreach (var uComp in _updatableComponents)
            {
                if (uComp is TType desiredComponent)
                    return desiredComponent;
            }

            foreach (var dComp in _drawableComponents)
            {
                if (dComp is TType desiredComponent)
                    return desiredComponent;
            }

            return null; // Возвращать null - плохо! Но что поделать...
        }

        /// <summary>
        /// Стандартный метод обновления
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime)
        {
            for (int index = 0; index < _updatableComponents.Count; index++)
            {
                _updatableComponents[index].Update(deltaTime);
            }
        }

        /// <summary>
        /// Стандартный метод рендера
        /// </summary>
        /// <param name="renderer"></param>
        public void Render(IRenderer renderer)
        {
            for (int index = 0; index < _drawableComponents.Count; index++)
            {
                _drawableComponents[index].Render(renderer);
            }
        }
    }
}
