using UnityEngine;

namespace Gameplay.Enemy
{
    [RequireComponent(typeof(EnemyAttacker), typeof(EnemyMovement))]
    public class EnemyStateMachine : MonoBehaviour
    {
        private readonly float _attackDistance = 0.5f;
        private readonly float _initalChaseDistance = 1f;
        private readonly float _finalChaseDistance = 3f;
        
        private EnemyAttacker _enemyAttacker;
        private EnemyMovement _enemyMovement;

        private WaitForSeconds _delay = new WaitForSeconds(1.5f);
        
        public Player.Player Player { get; set; }

        private bool _isPlayerClose;

        private void Awake()
        {
            _enemyAttacker = GetComponent<EnemyAttacker>();
            _enemyMovement = GetComponent<EnemyMovement>();
        }

        private void Update()
        {
            if(Player == null)
                return;
            
            float distance = Vector3.Distance(transform.position, Player.transform.position);

            if (distance < _attackDistance)
            {
                StartCoroutine(AttackWithDelay());
            }
            else if (distance >= _initalChaseDistance && distance <= _finalChaseDistance)
            {
                Vector3 direction = Player.transform.position - transform.position;
                _enemyMovement.Move(direction.normalized);
            }
        }

        private System.Collections.IEnumerator AttackWithDelay()
        {
            yield return _delay;
            
            _enemyAttacker.Attack(Player);
        }
    }
}