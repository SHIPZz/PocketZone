using System;
using Gameplay.Health;
using UnityEngine;

namespace Gameplay.Enemy
{
    [RequireComponent(typeof(EnemyDestruction))]
    public class Enemy : MonoBehaviour, IDamageable, ICharacter
    {
        [SerializeField] private int _healthValue;

        public event Action Dead;
        
        public IHealth Health { get; private set; }
        
        private void Awake()
        {
            Transform = gameObject.transform;
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
        
        public void TakeDamage(int damage)
        {
            Health.Decrease(damage);
        }

        private void Destroy() => 
            Dead?.Invoke();
    }
}