using Gameplay.Health;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _healthValue;
        
        private IHealth _health;
        
        public Transform Transform { get; private set; }
        
        private void Awake()
        {
            Transform = gameObject.transform;
            _health = new Health.Health(_healthValue);
            print("Хп игрока" + _health.CurrentValue);
        }

        public void TakeDamage(int damage)
        {
            _health.Decrease(damage);
        }
    }
}