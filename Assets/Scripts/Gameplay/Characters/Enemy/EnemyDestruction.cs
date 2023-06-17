using System;
using UnityEngine;

namespace Gameplay.Enemy
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyDestruction : MonoBehaviour
    {
        public event Action<Vector3> Destroyed;

        private readonly float _delay = 0.1f;
        
        private Enemy _enemy;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void OnEnable()
        {
            _enemy.Dead += Destroy;
        }

        private void OnDisable()
        {
            _enemy.Dead -= Destroy;
        }

        private void Destroy()
        {
            Destroyed?.Invoke(gameObject.transform.position);
            Destroy(gameObject, _delay);
        }
    }
}
