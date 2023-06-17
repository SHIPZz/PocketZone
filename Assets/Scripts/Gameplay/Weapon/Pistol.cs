using Services;
using Services.BulletFactory;
using Services.Databases;
using Services.DependencyContainer;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class Pistol : Weapon
    {
        private BulletFactory _bulletFactory;

        private void Awake()
        {
            WeaponDatabase.Add(this);
            ObjectTypeId = ObjectTypeId.Pistol;
            _bulletFactory = ServiceLocator.Get<BulletFactory>();
            BulletQuantity = Constant.Constant.PistolBulletsCount;
        }
        
        public override GameObject CreateBullet(Vector3 direction)
        {
            return _bulletFactory.CreatePistolBullet(ShootPoint.position, direction);
        }
    }
}
