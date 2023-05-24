using Gameplay.Health;
using UnityEngine;

namespace Gameplay.Enemy
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        private IHealth _health;

        private void Awake()
        {
            _health = new Health.Health(Constant.Constant.EnemyHealth);
            print("Хп врага" + _health.CurrentValue);
        }

        private void OnEnable()
        {
            _health.ValueZeroReached += Destroy;
        }

        private void OnDisable()
        {
            _health.ValueZeroReached -= Destroy;
        }

        public void TakeDamage(int damage)
        {
            _health.Decrease(damage);
        }

        private void Destroy() =>
            Destroy(gameObject);
    }
}