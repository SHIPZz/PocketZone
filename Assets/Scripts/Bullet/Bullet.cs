using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamagaeble damagaeble))
        {
            damagaeble.TakeDamage(_damage);
            Destroy(gameObject, 1.5f);
        }
    }
}