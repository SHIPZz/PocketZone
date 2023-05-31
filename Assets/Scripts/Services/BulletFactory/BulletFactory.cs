using Gameplay.Bullet;
using Services.DependencyContainer;
using Services.ObjectPool;
using UnityEngine;

namespace Services.BulletFactory
{
    public class BulletFactory
    {
        private GameObjectPool _bulletsPool;
        
        public BulletFactory()
        {
            _bulletsPool =  ServiceLocator.Get<ObjectPoolsAccess.ObjectPoolsAccess>().BulletsPool;
        }

        public GameObject CreateAkBullet(Vector3 shootPoint, Vector3 direction)
        {
            GameObject akBullet = _bulletsPool.Pop();

            akBullet.transform.position = shootPoint;
            
            akBullet.GetComponent<Bullet>().Init(Constant.Constant.AKBulletDamage);
            akBullet.GetComponent<BulletMovement>().Init(direction, Constant.Constant.AKBulletsSpeed);
            
            return akBullet;
        }

        public GameObject CreatePistolBullet(Vector3 shootPoint, Vector3 direction)
        {
            GameObject pistolBullets = _bulletsPool.Pop();

            pistolBullets.transform.position = shootPoint;
            
            pistolBullets.GetComponent<Bullet>().Init(Constant.Constant.PistolBulletDamage);
            pistolBullets.GetComponent<BulletMovement>().Init(direction, Constant.Constant.PistolBulletsSpeed);
        
        
            return pistolBullets;
        }
    }
}