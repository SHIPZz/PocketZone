using System.Collections.Generic;

namespace Services.DependencyContainer
{
    public class DependencyRegister
    {
        private List<object> _objects = new List<object>();

        public DependencyRegister()
        {
            ServiceLocator.Register(new ObjectPoolsAccess.ObjectPoolsAccess());
            ServiceLocator.Register(new BulletFactory.BulletFactory());
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