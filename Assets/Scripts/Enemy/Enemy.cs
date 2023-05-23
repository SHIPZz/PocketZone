using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagaeble
{
    private IHealth _health;

    private void Awake()
    {
        _health = new Health(Constant.EnemyHealth);
        print("Хп врага" + _health.CurrentValue);
    }

    private void OnEnable()
    {
        _health.ValueZeroReached += Destroy;
    }

    private void OnDisable()
    {
        _health.ValueZeroReached -= Destroy;
    }

    public void TakeDamage(int damage)
    {
        _health.Decrease(damage);
    }

    private void Destroy() =>
        Destroy(gameObject);
}