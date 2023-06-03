using UnityEngine;

namespace Gameplay.Enemy
{
    public class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] private int _damage;
        
        public void Attack(IDamageable damageable)
        {
            damageable.TakeDamage(_damage);
        }
    }
}