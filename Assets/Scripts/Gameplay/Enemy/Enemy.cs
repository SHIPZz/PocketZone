using System;
using Gameplay.Health;
using UnityEngine;

namespace Gameplay.Enemy
{
    [RequireComponent(typeof(EnemyDestruction))]
    public class Enemy : Character, IDamageable
    {
        [SerializeField] private int _healthValue;

        public event Action Dead;

        private void Awake()
        {
            Health = new Health.Health(_healthValue);
            print("Хп врага" + Health.CurrentValue);
        }

        public Transform Transform { get; private set; }

        private void OnEnable()
        {
            Health.ValueZeroReached += Destroy;
        }

        private void OnDisable()
        {
            Health.ValueZeroReached -= Destroy;
        }

        private void Destroy() => 
            Dead?.Invoke();
    }
}