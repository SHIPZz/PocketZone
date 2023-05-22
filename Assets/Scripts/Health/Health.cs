using System;
using UnityEngine;

public class Health : IHealth
{
    public Health(int currentValue)
    {
        CurrentValue = currentValue;
    }

    public int CurrentValue { get; private set; }

    public event Action<int> ValueChanged;

    public event Action<int> ValueZeroReached;

    public int MaxValue => CurrentValue;

    public void Increase(int value)
    {
        CurrentValue = Mathf.Clamp(CurrentValue + value, 0, MaxValue);
    }

    public void Decrease(int value)
    {
        CurrentValue = Mathf.Clamp(CurrentValue -  value, 0, MaxValue);
    }
}