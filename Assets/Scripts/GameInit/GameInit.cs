using System;
using System.Collections.Generic;
using System.Linq;
using Constant;
using Gameplay.Player;
using Gameplay.Weapon;
using Services;
using Services.Databases;
using Services.DependencyContainer;
using Services.GameFactory;
using Services.Window;
using UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace GameInit
{
    public class GameInit : MonoBehaviour
    {
        private DependencyRegister _dependencyRegister;
        private GameFactory _gameFactory;
        private readonly List<GameObject> _enemies = new ();
        private GameObject _player;

        private void Awake()
        {
            _dependencyRegister = new DependencyRegister();
            _gameFactory = ServiceLocator.Get<GameFactory>();
            var uiCreator = ServiceLocator.Get<UICreator>();

            InitializeInventory();
            CharacterSpawner[] spawners = InitializeCharacterSpawners();
            CreteCharacters(spawners);
            WeaponSelectorHandler weaponSelector = InitializeWeaponSelector(); 
            InitializePlayer(_player, weaponSelector);
            var windowService = ServiceLocator.Get<WindowService>();
            InitializeWindowService(windowService);
            InitializeBulletUI(uiCreator.MainUI, weaponSelector);
            InitializeItemTaker();
        }

        private void CreteCharacters(CharacterSpawner[] spawners)
        {
            foreach (CharacterSpawner spawner in spawners)
            {
                GameObject obj = spawner.Spawn();
                if (spawner.ObjectTypeId == ObjectTypeId.Player)
                    _player = obj;
                else
                    _enemies.Add(obj);
            }
        }

        private void Update()
        {
            _dependencyRegister.Update();
        }
        
        private void InitializeItemTaker()
        {
            // _itemTaker = _player.GetComponentInChildren<ItemTaker>();
            // _itemTaker.InventoryPresenter = _inventoryPresenter;
        }

        private CharacterSpawner[] InitializeCharacterSpawners() => 
            _gameFactory
                .CreateObject(AssetPath.CharacterSpawnerPrefab)
                .GetComponent<SpawnersCollection>()
                .AllSpawners;

        private void InitializePlayer(GameObject player, WeaponSelectorHandler weaponSelectorHandler)
        {
            var playerAttacker = player.GetComponent<PlayerAttacker>();
            playerAttacker.SetWeaponSelectorHandler(weaponSelectorHandler);
            var weaponMediator = weaponSelectorHandler.GetComponent<WeaponMediator>();
            weaponMediator.SetPlayerAttacker(playerAttacker);
        }

        private WeaponSelectorHandler InitializeWeaponSelector() =>
            _gameFactory.CreateObject(AssetPath.WeaponSelectorPrefab).GetComponent<WeaponSelectorHandler>();

        private void InitializeWindowService(WindowService windowService)
        {
            windowService.FillList(WindowDatabase.Values);
        }
        
        private void InitializeBulletUI(MainUI mainUI, WeaponSelectorHandler weaponSelectorHandler)
        {
            mainUI.BulletQuantityMediator.SetWeaponSelectorHandler(weaponSelectorHandler);

        }

        private void InitializeInventory()
        {
            // _inventoryPresenter = new InventoryPresenter(_inventory);
            // _inventoryPresenter = ServiceLocator.Get<InventoryPresenter>();
            // _inventoryView.SetInventoryPresenter(_inventoryPresenter);
        }
    }
}