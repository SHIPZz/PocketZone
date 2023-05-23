using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    public event Action TriggerEntered;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamagaeble damagaeble))
        {
            damagaeble.TakeDamage(_damage);
        }

        TriggerEntered?.Invoke();
    }
}