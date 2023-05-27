using System;
using Gameplay.Player;
using Gameplay.Weapon;
using Services;
using Services.DependencyContainer;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace GameInit
{
    public class GameInit : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private WeaponSelectorHandler _weaponHandler;
        [SerializeField] private ItemTaker itemTaker;
        [SerializeField] private InventoryPresenter _inventoryPresenter;
        [SerializeField] private InventoryView _inventoryView;

        private PlayerAttacker _playerAttacker;
        private PlayerInput _playerInput;
        private  DependencyRegister _dependencyRegister;

        private void Awake()
        {
            _dependencyRegister = new DependencyRegister();
            
            _inventoryView.SetInventoryPresenter(_inventoryPresenter);
            SetDependenciesForPlayer();
        }

        private void Start()
        {

            // _addingItemMediator.InventoryView = _inventoryView;
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