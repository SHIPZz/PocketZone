using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamagaeble
{
    public  IHealth Health { get; set; }

    private void Start()
    {
        print("Хп игрока" + Health.CurrentValue);
    }

    public void TakeDamage(int damage)
    {
        Health.Decrease(damage);
    }
}