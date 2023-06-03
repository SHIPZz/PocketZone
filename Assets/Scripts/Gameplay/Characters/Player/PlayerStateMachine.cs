using System;
using Services;
using Services.DependencyContainer;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private PlayerAttacker _playerAttacker;
        private InputService _inputService;

        private void Awake()
        {
            _inputService = ServiceLocator.Get<InputService>();
            _playerAttacker = GetComponent<PlayerAttacker>();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (_inputService.GetAxis() != null && _inputService.IsAttackInvoked() == false)
            {
                _playerMovement.Move(_inputService.GetAxis());
            }
            else if (_inputService.IsAttackInvoked() == true)
            {
                _playerAttacker.Attack();
            }
        }
    }
}