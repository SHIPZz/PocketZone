using System;
using Gameplay.Health;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player : MonoBehaviour, IDamageable, ICharacter
    {
        [SerializeField] private int _healthValue;

        public event Action<GameObject> ItemFaced;
        
        public IHealth Health { get; private set; }
        
        public Transform Transform { get; private set; }
        
        private void Awake()
        {
            Transform = gameObject.transform;
            Health = new Health.Health(_healthValue);
            print("Хп игрока" + Health.CurrentValue);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer == 8)
                ItemFaced?.Invoke(other.gameObject);
        }

        public void TakeDamage(int damage)
        {
            Health.Decrease(damage);
        }
    }
}