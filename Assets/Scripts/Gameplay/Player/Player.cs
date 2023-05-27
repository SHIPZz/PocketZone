using System;
using Gameplay.Health;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _healthValue;

        public event Action<GameObject> ItemFaced;
        
        private IHealth _health;
        
        public Transform Transform { get; private set; }
        
        private void Awake()
        {
            Transform = gameObject.transform;
            _health = new Health.Health(_healthValue);
            print("Хп игрока" + _health.CurrentValue);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer == 8)
                ItemFaced?.Invoke(other.gameObject);
        }

        public void TakeDamage(int damage)
        {
            _health.Decrease(damage);
        }
    }
}