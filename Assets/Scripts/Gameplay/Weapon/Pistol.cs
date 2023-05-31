using System;
using Services.BulletFactory;
using Services.DependencyContainer;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class Pistol : Weapon
    {
        private BulletFactory _bulletFactory;

        private void Awake()
        {
            _bulletFactory = ServiceLocator.Get<BulletFactory>();
            BulletQuantity = Constant.Constant.PistolBulletsCount;
        }
        
        public override GameObject CreateBullet(Vector3 direction)
        {
            return _bulletFactory.CreatePistolBullet(ShootPoint.position, direction);
        }
    }
}
