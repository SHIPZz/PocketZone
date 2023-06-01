using System;
using Services;
using Services.BulletFactory;
using Services.Databases;
using Services.DependencyContainer;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class AK : Weapon
    {
        private BulletFactory _bulletFactory;

        private void Awake()
        {
            WeaponDatabase.Add(this);
            ObjectTypeId = ObjectTypeId.AK;
            _bulletFactory = ServiceLocator.Get<BulletFactory>();
            BulletQuantity = Constant.Constant.AKBulletsCount;
        }

        public override GameObject CreateBullet(Vector3 direction)
        {
            return _bulletFactory.CreateAkBullet(ShootPoint.position, direction);
        }
    }
}
