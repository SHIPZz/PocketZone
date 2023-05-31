using System;
using System.Collections.Generic;
using System.Linq;
using Constant;
using Gameplay.Player;
using Gameplay.Weapon;
using Services;
using Services.DependencyContainer;
using Services.GameFactory;
using Services.Window;
using UI;
using UnityEngine;

namespace GameInit
{
    public class GameInit : MonoBehaviour
    {
        [SerializeField] private BulletQuantityMediator _bulletQuantityMediator;
        // [SerializeField] private MainUI _mainUI;
        
        private InventoryView _inventoryView;
        private WeaponMediator _weaponMediator;
        private BulletQuantityText _bulletQuantityText;
        private Player _player;
        private PlayerAttacker _playerAttacker;
        private PlayerInput _playerInput;
        private  DependencyRegister _dependencyRegister;
        private InventoryPresenter _inventoryPresenter;
        private WindowService _windowService;
        private GameFactory _gameFactory;
        private Canvas _inventoryCanvas;
        private WeaponSelectorHandler _weaponSelectorHandler;

        private void Awake()
        {
            _dependencyRegister = new DependencyRegister();
            _gameFactory = ServiceLocator.Get<GameFactory>();

            InitializeInventory();
            
            InitializeCharacterSpawners();
            
            InitializePlayer();
            
            InitializeWeaponSelector();
            
            InitializeWeaponMediator();
            
            
            InitializeWindowService();
            
            InitializeBulletQuantityMediator();
            
            InitializeBulletMediator();
        }

        private void Update()
        {
            _dependencyRegister.Update();
        }

        private void InitializeWeaponMediator()
        {
            _weaponMediator = _weaponSelectorHandler.GetComponent<WeaponMediator>();
            _weaponMediator.SetPlayerAttacker(_playerAttacker);
        }
        
        private void InitializeCharacterSpawners()
        {
            var characterSpawners = _gameFactory.CreateObject(AssetPath.ObjectSpawnersPrefab);

            foreach (var characterSpawner in CharacterSpawnerDatabase.Values)
            {
                characterSpawner.SetParentForHealthbar(WindowDatabase.Get(WindowTypeId.Health).gameObject);
            }
        }

        private void InitializePlayer()
        {
            print(CharacterSpawnerDatabase.Values.Count);
            GameObject playerPrefab = CharacterSpawnerDatabase.Get(SpawnObjectTypeId.Player).gameObject;
            _player = playerPrefab.GetComponent<Player>();
            
            _playerAttacker = playerPrefab.GetComponent<PlayerAttacker>();
            _playerInput = playerPrefab.GetComponent<PlayerInput>();

            _playerAttacker.SetPlayerInput(_playerInput);
            _playerAttacker.SetWeaponSelectorHandler(_weaponSelectorHandler);
        }
        
        private void InitializeWeaponSelector()
        {
            var weapons = _player.GetComponentsInChildren<Weapon>().ToList();
            _weaponSelectorHandler = _gameFactory.CreateObject(AssetPath.WeaponSelectorPrefab)
                .GetComponent<WeaponSelectorHandler>();
            _weaponSelectorHandler.FillList(weapons);
        }

        private void InitializeWindowService()
        {
            _windowService = ServiceLocator.Get<WindowService>();
            _windowService.FillList(WindowDatabase.Values);
        }
        
        private void InitializeBulletQuantityMediator()
        {
            // _bulletQuantityMediator.SetBulletQuantityText(_weaponSelectorHandler.GetComponentInChildren<BulletQuantityText>());
            // _bulletQuantityMediator.SetWeaponSelectorHandler(_weaponSelectorHandler);
        }
        
        private void InitializeBulletMediator()
        {
            // _bulletQuantityMediator.SetBulletQuantityText(_bulletQuantityText);
            // _bulletQuantityMediator.SetWeaponSelectorHandler(_weaponSelectorHandler);
        }
        
        private void InitializeInventory()
        {
            // _inventoryPresenter = ServiceLocator.Get<InventoryPresenter>();
            // _inventoryView.SetInventoryPresenter(_inventoryPresenter);
        }
    }
}