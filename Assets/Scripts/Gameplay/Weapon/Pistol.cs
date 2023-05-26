using Services.BulletFactory;
using Services.DependencyContainer;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class Pistol : Weapon
    {
        private BulletFactory _bulletFactory;

        private void Start()
        {
            _bulletFactory = ServiceLocator.Get<BulletFactory>();
        }

        public override GameObject CreateBullet(Vector3 direction)
        {
            return _bulletFactory.CreatePistolBullet(ShootPoint.position, direction);
        }
    }
}
