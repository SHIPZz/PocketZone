using System;
using Gameplay.Health;
using Services;
using UnityEngine;

namespace Gameplay
{
    public abstract class Character : MonoBehaviour, IDamageable
    { 
        [field: SerializeField] public ObjectTypeId ObjectTypeId { get; protected set; }

        public event Action Dead;
        public event Action<Transform> TransformChanged;
        
        public IHealth Health { get; protected set; }

        private void OnEnable()
        {
            Health.ValueZeroReached += Destroy;
        }

        private void OnDisable()
        {
            Health.ValueZeroReached -= Destroy;
        }
        
        private void Update()
        {
            TransformChanged?.Invoke(gameObject.transform);
        }

        public void TakeDamage(int damage)
       {
           Health.Decrease(damage);
       }
        
        private void Destroy() => 
            Dead?.Invoke();
    }
}