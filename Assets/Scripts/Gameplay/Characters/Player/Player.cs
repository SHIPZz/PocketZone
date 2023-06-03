using System;
using UnityEngine;

namespace Gameplay.Player
{
    public class Player : Character
    {
        [SerializeField] private int _healthValue;

        private void Awake()
        {
            Health = new Health.Health(_healthValue);
        }
    }
}