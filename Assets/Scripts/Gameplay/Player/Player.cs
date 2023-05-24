using Gameplay.Health;
using Gameplay.IDamageable;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player : MonoBehaviour, IDamagaeble
    {
        private IHealth _health;

        private void Awake()
        {
            _health = new Health.Health(Constant.Constant.PlayerHealth);
            print("Хп игрока" + _health.CurrentValue);
        }

        public void TakeDamage(int damage)
        {
            _health.Decrease(damage);
        }
    }
}