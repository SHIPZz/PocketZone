using System;
using UnityEngine;

namespace Gameplay.Health
{
    public class Health : IHealth
    {
        public Health(int currentValue)
        {
            CurrentValue = currentValue;
        }

        public int CurrentValue { get; private set; }

        public event Action<int> ValueChanged;

        public event Action ValueZeroReached;

        public int MaxValue => CurrentValue;

        public void Increase(int value)
        {
            CurrentValue = Mathf.Clamp(CurrentValue + value, 0, MaxValue);

            ValueChanged?.Invoke(CurrentValue);
        }

        public void Decrease(int value)
        {
            CurrentValue = Mathf.Clamp(CurrentValue -  value, 0, MaxValue);
        
            if(CurrentValue == 0)
                ValueZeroReached?.Invoke();
        
            ValueChanged?.Invoke(CurrentValue);
        }
    }
}