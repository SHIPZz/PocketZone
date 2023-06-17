using System;
using Services;
using UnityEngine;

namespace Gameplay.Weapon
{
    public abstract  class Weapon : MonoBehaviour, IReloadeable
    {
        [SerializeField] protected Transform ShootPoint;
        [SerializeField] protected float FireRate;
        
        [field: SerializeField] public ObjectTypeId ObjectTypeId { get; protected set; }

        public int BulletQuantity { get; protected set; }
        
        public event Action<int, Weapon> BulletsChanged;
        
        private float _fireTimer;

        private int _initalBulletQuantity;

        private void Start()
        {
            _initalBulletQuantity = BulletQuantity;
        }

        private void Update()
        {
            _fireTimer += Time.deltaTime;
        }

        public abstract GameObject CreateBullet(Vector3 direction);
        
        public void Shoot(Vector3 targetPosition)
        {
            BulletQuantity--;

            if (IsBulletQuantityNull()) 
                return;
            
            if (_fireTimer < FireRate) 
                return;

            Vector3 direction = Direction(targetPosition);

            GameObject bullet = CreateBullet(direction.normalized);
            _fireTimer = 0;
            
            BulletsChanged?.Invoke(BulletQuantity, this);
        }

        private bool IsBulletQuantityNull()
        {
            if (BulletQuantity <= 0)
            {
                BulletQuantity = 0;
                BulletsChanged?.Invoke(BulletQuantity, this);
                return true;
            }

            return false;
        }


        
        public void Reload()
        {
            BulletQuantity = _initalBulletQuantity;
            BulletsChanged?.Invoke(BulletQuantity, this);
        }
        
        private Vector3 Direction(Vector3 targetPosition)
        {
            var heading = targetPosition - ShootPoint.position;
            var distance = heading.magnitude;
            var direction = heading / distance;
            return direction;
        }
    }
}
