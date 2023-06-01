using System.Collections.Generic;
using GameInit;
using Services.Window;
using UI;

namespace Services.DependencyContainer
{
    public class DependencyRegister
    {
        private List<object> _objects = new List<object>();

        public DependencyRegister()
        {
            ServiceLocator.Register(new ObjectPoolsAccess.ObjectPoolsAccess());
            ServiceLocator.Register(new BulletFactory.BulletFactory());
            ServiceLocator.Register(new GameFactory.GameFactory());
            ServiceLocator.Register(new WindowService());
            ServiceLocator.Register(new UICreator());
            InputService inputService = new InputService();
            ServiceLocator.Register(inputService);
            _objects.Add(inputService);
        }

        public void Update()
        {
            foreach (var @object in _objects)
            {
                if(@object is IUpdateable updateable)
                    updateable.Update();
            }
        }
    }
}