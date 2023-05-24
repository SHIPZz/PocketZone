using UnityEngine;

namespace Gameplay.Weapon
{
    public abstract  class Weapon : MonoBehaviour
    {
        [SerializeField] protected Transform ShootPoint;
        [SerializeField] protected float FireRate;
    
        private float _fireTimer;

        private void Update()
        {
            _fireTimer += Time.deltaTime;
        }

        public void Shoot(Vector3 targetPosition)
        {
            if (_fireTimer < FireRate) 
                return;

            var heading = targetPosition - ShootPoint.position;
            var distance = heading.magnitude;
            var direction = heading / distance;
        
            GameObject bullet = CreateBullet(direction.normalized);
            _fireTimer = 0;
        }

        public abstract GameObject CreateBullet(Vector3 direction);
    }
}
