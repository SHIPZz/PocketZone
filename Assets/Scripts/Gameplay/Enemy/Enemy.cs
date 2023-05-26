using System;
using Gameplay.Health;
using UnityEngine;

namespace Gameplay.Enemy
{
    [RequireComponent(typeof(EnemyDestruction))]
    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _healthValue;

        public event Action Dead;
        
        private IHealth _health;
        
        private void Awake()
        {
            Transform = gameObject.transform;
            _health = new Health.Health(_healthValue);
            print("Хп врага" + _health.CurrentValue);
        }

        public Transform Transform { get; private set; }

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
            Dead?.Invoke();
    }
}