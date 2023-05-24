using Constant;
using Services.ObjectPool;
using UnityEngine;

namespace Services.ObjectPoolsAccess
{
    public class ObjectPoolsAccess
    {
        public GameObjectPool BulletsPool { get; }
        
        public ObjectPoolsAccess()
        {
            GameObject bulletPrefab = Resources.Load<GameObject>(AssetPath.BulletPrefab);
            
            BulletsPool = new GameObjectPool(() => Object.Instantiate(bulletPrefab),Constant.Constant.AKBulletsCount);
        }
    }
}