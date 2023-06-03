using UnityEngine;

namespace Gameplay.Enemy
{
    public class EnemyStateMachine : MonoBehaviour
    {
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

            if (distance < 0.5f)
            {
                StartCoroutine(AttackWithDelay());
            }
            else if (distance >= 1f && distance <= 3f)
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