using System.Collections.Generic;
using Constant;
using Gameplay.Enemy;
using Gameplay.Player;
using Gameplay.Weapon;
using Services;
using Services.Databases;
using Services.DependencyContainer;
using Services.GameFactory;
using Services.Window;
using UI;
using UnityEngine;

namespace GameInit
{
    public class GameInit : MonoBehaviour
    {
        private readonly List<GameObject> _enemies = new ();
        private DependencyRegister _dependencyRegister;
        private GameFactory _gameFactory;
        private GameObject _player;
        private InventoryPresenter _inventoryPresenter;

        private void Awake()
        {
            _dependencyRegister = new DependencyRegister();
            _gameFactory = ServiceLocator.Get<GameFactory>();
            var uiCreator = ServiceLocator.Get<UICreator>();

            InitializeInventory(uiCreator.MainUI);
            CharacterSpawner[] spawners = InitializeCharacterSpawners();
            CreateCharacters(spawners);
            WeaponSelectorHandler weaponSelector = InitializeWeaponSelector(); 
            InitializePlayer(_player, weaponSelector);
            InitializeEnemy(_player.GetComponent<Player>());
            var windowService = ServiceLocator.Get<WindowService>();
            InitializeDynamicItemRemoverMediators();
            InitializeWindowService(windowService);
            InitializeBulletUI(uiCreator.MainUI, weaponSelector);
            InitializeItemTaker();
            InitializeInputHandler(weaponSelector);
        }

        private void InitializeDynamicItemRemoverMediators()
        {
            foreach (var dynamicItem in DynamicItemDatabase.Values)
            {
                var dynamicItemRemoverMediator = dynamicItem.GetComponent<DynamicItemRemoverMediator>();
                dynamicItemRemoverMediator.InventoryPresenter = _inventoryPresenter;
            }
        }

        private void InitializeInputHandler(WeaponSelectorHandler weaponSelectorHandler)
        {
            var inputHandler = _gameFactory.CreateObject(AssetPath.InputHandler).GetComponent<InputHandler>();

            inputHandler.WeaponSelectorHandler = weaponSelectorHandler;
        }

        private void CreateCharacters(CharacterSpawner[] spawners)
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

        private void InitializeEnemy(Player player)
        {
            foreach (var enemy in _enemies)
            {
                enemy.GetComponent<EnemyStateMachine>().Player = player;
            }
        }

        private void InitializeItemTaker()
        {
            var itemTaker = _player.GetComponentInChildren<ItemTaker>();
            itemTaker.InventoryPresenter = _inventoryPresenter;
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
            
            playerAttacker.SetWeapon(weaponSelectorHandler.Weapon);
        }

        private WeaponSelectorHandler InitializeWeaponSelector()
        {
           var weaponSelectorHandler =  _gameFactory.CreateObject(AssetPath.WeaponSelectorPrefab).
               GetComponent<WeaponSelectorHandler>();

           return weaponSelectorHandler;
        }

        private void InitializeWindowService(WindowService windowService)
        {
            windowService.FillList(WindowDatabase.Values);
        }
        
        private void InitializeBulletUI(MainUI mainUI, WeaponSelectorHandler weaponSelectorHandler)
        {
            mainUI.BulletQuantityMediator.SetWeaponSelectorHandler(weaponSelectorHandler);
        }

        private void InitializeInventory(MainUI mainUI)
        {
            Inventory inventory = new Inventory();
            _inventoryPresenter = new InventoryPresenter(inventory);
            mainUI.InventoryView.SetInventoryPresenter(_inventoryPresenter);
        }
    }
}