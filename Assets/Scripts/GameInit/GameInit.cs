using System;
using Gameplay.Player;
using Gameplay.Weapon;
using Services;
using Services.DependencyContainer;
using UnityEngine;
using UnityEngine.UI;

namespace GameInit
{
    public class GameInit : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private WeaponSelectorHandler _weaponHandler;

        private PlayerAttacker _playerAttacker;
        private PlayerInput _playerInput;
        private  DependencyRegister _dependencyRegister;

        private void Awake()
        {
            _dependencyRegister = new DependencyRegister();

            SetDependenciesForPlayer();
        }
        
        private void Update()
        {
            _dependencyRegister.Update();
        }

        private void SetDependenciesForPlayer()
        {
            _playerAttacker = _player.GetComponent<PlayerAttacker>();
            _playerInput = _player.GetComponent<PlayerInput>();
            
            _playerAttacker.SetPlayerInput(_playerInput);
            _playerAttacker.SetWeaponSelectorHandler(_weaponHandler);
        }
    }
}