using System;
using System.Collections;
using Gameplay.IDamageable;
using Services.DependencyContainer;
using Services.ObjectPool;
using Services.ObjectPoolsAccess;
using UnityEngine;

namespace Gameplay.Bullet
{
    public class Bullet : MonoBehaviour
    {
        public event Action TriggerEntered;

        private int _damage;
        private GameObjectPool _bulletsPool;
        private Coroutine _delayCoroutine;

        private void Start()
        {
            _bulletsPool = ServiceLocator.Get<ObjectPoolsAccess>().BulletsPool;
            _delayCoroutine = StartCoroutine(DisableCoroutine());
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamagaeble damagaeble))
            {
                damagaeble.TakeDamage(_damage);
            }
            
            TriggerEntered?.Invoke();
            StopCoroutine(_delayCoroutine);
            Disable();
        }

        public void Init(int damage)
        {
            _damage = damage;
        }

        private void Disable()
        {
            _bulletsPool.Push(gameObject);
        }

        private IEnumerator DisableCoroutine()
        {
            yield return new WaitForSeconds(2f);
            Disable();
        }
    }
}