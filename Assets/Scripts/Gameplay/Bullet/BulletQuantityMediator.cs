using System;
using System.Collections.Generic;
using Gameplay.Weapon;
using Services;
using UnityEngine;

namespace UI
{
    public class BulletQuantityMediator : MonoBehaviour
    {
        private WeaponSelectorHandler _weaponSelectorHandler;
        private Dictionary<Weapon, int> _bulletQuantities;
        private BulletQuantityText _bulletQuantityText;

        private Weapon _currentWeapon;

        private void Awake()
        {
            _bulletQuantityText = GetComponentInChildren<BulletQuantityText>();
        }

        private void Start()
        {
            _bulletQuantities = new Dictionary<Weapon, int>();

            foreach (var weapon in _weaponSelectorHandler.Weapons)
            {
                _bulletQuantities.Add(weapon, weapon.BulletQuantity);
            }

            _currentWeapon = _weaponSelectorHandler.Weapon;
            _bulletQuantityText.Weapon = _currentWeapon;
            _weaponSelectorHandler.ChoosedWeapon += OnChoosedWeapon;
            _weaponSelectorHandler.OldWeaponSwitched += LastWeaponChoosed;
            _currentWeapon.BulletsChanged += OnBulletsChanged;
        }
        
        private void OnDisable()
        {
            _currentWeapon.BulletsChanged -= OnBulletsChanged;
            _weaponSelectorHandler.OldWeaponSwitched -= LastWeaponChoosed;
            _weaponSelectorHandler.ChoosedWeapon -= OnChoosedWeapon;
        }

        private void OnBulletsChanged(int obj, Weapon weapon)
        {
            _currentWeapon = weapon;
            
            _bulletQuantities[_currentWeapon] = obj;
            
            Debug.Log(weapon);
            
            _bulletQuantityText.Weapon = _currentWeapon;
        }
        
        private void OnChoosedWeapon(Weapon weapon)
        {
            _currentWeapon = weapon;
            _bulletQuantityText.Weapon = _currentWeapon;
        }

        private void LastWeaponChoosed(Weapon weapon)
        {
            if (_currentWeapon != null)
            {
                _bulletQuantities[_currentWeapon] = _currentWeapon.BulletQuantity;
            }
    
            _currentWeapon = weapon;
            _bulletQuantityText.Weapon = _currentWeapon;
        }
        
        public void SetWeaponSelectorHandler(WeaponSelectorHandler weaponSelectorHandler)
        {
            _weaponSelectorHandler = weaponSelectorHandler;
        }
    }
}
