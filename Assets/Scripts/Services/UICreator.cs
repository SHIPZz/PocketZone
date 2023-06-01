using Constant;
using Gameplay;
using Gameplay.Health;
using Services.DependencyContainer;
using Services.GameFactory;
using Services.Window;
using UI;
using UI.Health;
using UnityEngine;

namespace GameInit
{
    public class UICreator
    {
        public MainUI MainUI { get; private set; }
        
        private readonly GameFactory _gameFactory;
        private readonly WindowService _windowService;

        public UICreator()
        {
            _gameFactory = ServiceLocator.Get<GameFactory>();
            _windowService = ServiceLocator.Get<WindowService>();
            MainUI =  CreateMainUI();
            // CreateInventory();
        }

        public GameObject CreateHealthbar(IHealth health)
        {
            var healthbar = _gameFactory.CreateObject(AssetPath.HealthbarPrefab);
            var healthView = healthbar.GetComponentInChildren<HealthView>();
            HealthPresenter healthbarPresenter = new HealthPresenter(healthView, health);

            return healthbar;
        }

        private MainUI CreateMainUI()
        {
            return _gameFactory.CreateObject(AssetPath.UIPrefab).GetComponent<MainUI>();
        }
        
        private GameObject CreateInventoryWindow()
        {
            var inventoryWindow = _gameFactory.CreateObject(AssetPath.InventoryPrefab);
            inventoryWindow.SetActive(false);
            var window = inventoryWindow.GetComponent<UI.Window>();
            // window.WindowTypeId = WindowTypeId.Inventory;
            // _windowService.FillList(window);
            
            return inventoryWindow;
        }

        private GameObject CreateInputWindow()
        {
            var inputWindow = _gameFactory.CreateObject(AssetPath.InputCanvasPrefab);
            inputWindow.SetActive(false);
            var window = inputWindow.GetComponent<UI.Window>();
            // window.WindowTypeId = WindowTypeId.Input;
            // _windowService.FillList(window);

            return inputWindow;
        }
    }
}