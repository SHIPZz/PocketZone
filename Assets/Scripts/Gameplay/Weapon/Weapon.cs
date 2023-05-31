using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Weapon
{
    public abstract  class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform ShootPoint;
        [SerializeField] protected float FireRate;

        public int BulletQuantity { get; set; }
        
        public event Action Shooted;
        public event Action<int, Weapon> BulletsChanged;
        
        private float _fireTimer;

        private void Update()
        {
            _fireTimer += Time.deltaTime;
        }

        public void Shoot(Vector3 targetPosition)
        {
            BulletQuantity--;

            if (BulletQuantity <= 0)
            {
                BulletQuantity = 0;
                BulletsChanged?.Invoke(BulletQuantity, this);
                return;
            }
            
            if (_fireTimer < FireRate) 
                return;

            var heading = targetPosition - ShootPoint.position;
            var distance = heading.magnitude;
            var direction = heading / distance;
        
            GameObject bullet = CreateBullet(direction.normalized);
            _fireTimer = 0;

            BulletsChanged?.Invoke(BulletQuantity, this);
            Shooted?.Invoke();
        }

        public abstract GameObject CreateBullet(Vector3 direction);
    }
}
