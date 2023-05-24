using UnityEngine;

namespace Gameplay.Bullet
{
    public class BulletMovement : MonoBehaviour
    {
        private int _speed;
        private Vector3 _direction;
        private Rigidbody2D _rigidbody2D;

        private void Update()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        public void Init(Vector3 direction, int speed)
        {
            _speed = speed;
            _direction = direction;
        }
    }
}