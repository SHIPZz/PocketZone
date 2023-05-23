using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamagaeble
{
    private IHealth _health;

    private void Awake()
    {
        _health = new Health(Constant.PlayerHealth);
        print("Хп врага" + _health.CurrentValue);
    }

    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);
    }
}