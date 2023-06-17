using UnityEngine;

namespace Gameplay.Enemy
{
    public class Enemy : Character
    {
        [SerializeField] private int _healthValue;

        private void Awake()
        {
            Health = new Health.Health(_healthValue);
        }
    }
}