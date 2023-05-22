using System;
using UnityEngine;

namespace GameInit
{
    public class GameInit : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Enemy _enemy;
        
        private  DependencyRegister _dependencyRegister = new DependencyRegister();
        private IHealth _enemyHealth;
        private IHealth _playerHealth;

        private void Awake()
        {
            _enemyHealth = DependencyContainer.Get<IHealth>();
            _playerHealth = DependencyContainer.Get<IHealth>();
            
            _player.Health = _playerHealth;
            _enemy.Health = _enemyHealth;
        }
        
    }
}