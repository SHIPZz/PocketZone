using GameInit;
using Services.Window;

namespace Services.DependencyContainer
{
    public class DependencyRegister
    {
        public DependencyRegister()
        {
            ServiceLocator.Register(new ObjectPoolsAccess.ObjectPoolsAccess());
            ServiceLocator.Register(new BulletFactory.BulletFactory());
            ServiceLocator.Register(new GameFactory.GameFactory());
            ServiceLocator.Register(new WindowService());
            ServiceLocator.Register(new UICreator());
            InputService inputService = new InputService();
            ServiceLocator.Register(inputService);
        }
    }
}