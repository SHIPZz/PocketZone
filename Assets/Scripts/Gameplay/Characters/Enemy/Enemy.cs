using System;
using Gameplay.Health;
using UnityEngine;

namespace Gameplay.Enemy
{
    [RequireComponent(typeof(EnemyDestruction))]
    public class Enemy : Character, IDamageable
    {
        [SerializeField] private int _healthValue;

        private void Awake()
        {
            Health = new Health.Health(_healthValue);
        }
    }
}