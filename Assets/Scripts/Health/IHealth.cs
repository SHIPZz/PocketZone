using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    int CurrentValue { get; }
    void Increase(int value);
    void Decrease(int value);
}
