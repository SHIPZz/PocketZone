using System.Collections.Generic;
using Gameplay.Weapon;
using Services;
using Services.Databases;
using UnityEngine;

namespace UI
{
    public class BulletQuantityMediator : MonoBehaviour
    {
        private WeaponSelectorHandler _weaponSelectorHandler;
        private Dictionary<Weapon, int> _bulletQuantities = new Dictionary<Weapon, int>();
        private BulletQuantityText _bulletQuantityText;

        private void Awake()
        {
            _bulletQuantityText = GetComponentInChildren<BulletQuantityText>();
        }

        private void Start()
        {
            foreach (var weapon in WeaponDatabase.Values)
            {
                weapon.BulletsChanged += OnBulletsChanged;
                _bulletQuantities.Add(weapon, weapon.BulletQuantity);
            }
            
            _weaponSelectorHandler.ChoosedWeapon += OnChoosedWeapon;
            _weaponSelectorHandler.OldWeaponSwitched += LastWeaponChoosed;
        }
        
        private void OnDisable()
        {
            foreach (var weapon in WeaponDatabase.Values)
            {
                weapon.BulletsChanged -= OnBulletsChanged;
            }
            
            _weaponSelectorHandler.OldWeaponSwitched -= LastWeaponChoosed;
            _weaponSelectorHandler.ChoosedWeapon -= OnChoosedWeapon;
        }

        private void OnBulletsChanged(int count, Weapon weapon)
        {
            _bulletQuantities[weapon] = count;

            _bulletQuantityText.Set(weapon.BulletQuantity);
        }
        
        private void OnChoosedWeapon(Weapon weapon)
        {
            _bulletQuantityText.Set(weapon.BulletQuantity);
        }

        private void LastWeaponChoosed(Weapon weapon)
        {
            _bulletQuantities[weapon] = weapon.BulletQuantity;
        }
        
        public void SetWeaponSelectorHandler(WeaponSelectorHandler weaponSelectorHandler)
        {
            _weaponSelectorHandler = weaponSelectorHandler;
        }
    }
}
