using System;
using Services.BulletFactory;
using Services.DependencyContainer;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class AK : Weapon
    {
        private BulletFactory _bulletFactory;

        private void Awake()
        {
            _bulletFactory = ServiceLocator.Get<BulletFactory>();
            BulletQuantity = Constant.Constant.AKBulletsCount;
        }

        public override GameObject CreateBullet(Vector3 direction)
        {
            return _bulletFactory.CreateAkBullet(ShootPoint.position, direction);
        }
    }
}
