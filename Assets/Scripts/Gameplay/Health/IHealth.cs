using System;

namespace Gameplay.Health
{
    public interface IHealth
    {
        event Action<int> ValueChanged;
        event Action ValueZeroReached;
    
        int CurrentValue { get; }
        void Increase(int value);
        void Decrease(int value);
    }
}
