using System;
using Gameplay.Health;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player : Character, IDamageable
    {
        [SerializeField] private int _healthValue;

        public event Action<GameObject> ItemFaced;

        private void Awake()
        {
            Health = new Health.Health(_healthValue);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer == 8)
                ItemFaced?.Invoke(other.gameObject);
        }
    }
}