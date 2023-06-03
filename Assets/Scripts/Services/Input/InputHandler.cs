using DG.Tweening;
using Services.DependencyContainer;
using Services.Window;
using UnityEngine;

namespace Services
{
    public class InputHandler : MonoBehaviour
    {
        private InputService _inputService;
        private WindowService _windowService;

        public WeaponSelectorHandler WeaponSelectorHandler { get; set; }
        
        private void Awake()
        {
            _inputService = ServiceLocator.Get<InputService>();
            _windowService = ServiceLocator.Get<WindowService>();
        }

        private void Update()
        {
            WeaponSwitching();

            InventoryOpening();

            WeaponReloading();

            WindowControlling();
        }

        private void WindowControlling()
        {
            if (_inputService.IsInventoryOpened())
            {
                print("1");
                _windowService.CloseAll();
                _windowService.OpenWindow(WindowTypeId.Inventory);
            }
            else if (_inputService.IsInventoryClosed())
            {
                _windowService.CloseAll();
                _windowService.OpenHudWindows();
            }
        }

        private void WeaponReloading()
        {
            if (_inputService.IsReloaded())
            {
                var weapon = WeaponSelectorHandler.Weapon;
                weapon.Reload();
            }
        }

        private void InventoryOpening()
        {
            if (_inputService.IsInventoryOpened())
                WindowDatabase.Get(WindowTypeId.Inventory).gameObject.transform.DOScale(1, 1);
            else if (_inputService.IsInventoryClosed())
                WindowDatabase.Get(WindowTypeId.Inventory).gameObject.transform.DOScale(0, 0.5f);
        }

        private void WeaponSwitching()
        {
            if (_inputService.IsNextWeaponInvoked())
                WeaponSelectorHandler.SelectNextWeapon();
            else if (_inputService.IsPreviousWeaponInvoked())
                WeaponSelectorHandler.SelectPreviousWeapon();
        }
    }
}