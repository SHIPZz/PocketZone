using UnityEngine;

namespace Gameplay.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private int _speed;
        
        public void Move(Vector3 direction)
        {
            transform.Translate(direction * _speed * Time.deltaTime);
        }
    }
}