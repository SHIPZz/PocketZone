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
        }

        public GameObject CreateHealthbar(Gameplay.Character character)
        {
            var healthbar = _gameFactory.CreateObject(AssetPath.HealthbarPrefab);
            HealthView healthView = healthbar.GetComponentInChildren<HealthView>();
            HealthPresenter healthPresenter = new HealthPresenter(healthView, character);

            return healthbar;
        }

        private MainUI CreateMainUI()
        {
            return _gameFactory.CreateObject(AssetPath.UIPrefab).GetComponent<MainUI>();
        }
    }
}