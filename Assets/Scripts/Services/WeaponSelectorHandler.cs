using System;
using System.Collections.Generic;
using Extensions.GameObjectExtension;
using Gameplay.Weapon;
using Services.Databases;
using UnityEngine;

namespace Services
{
    public class WeaponSelectorHandler : MonoBehaviour
    {
         private List<Weapon> _weapons = new List<Weapon>();
        
        public event Action<Weapon> ChoosedWeapon;
        public event Action<Weapon> OldWeaponSwitched; 

        private int _currentWeapon = 0;

        public IReadOnlyList<Weapon> Weapons =>
            _weapons;
        
        public Weapon Weapon { get; private set; }

        private void Awake()
        {
            _weapons = WeaponDatabase.Values;
            Weapon = _weapons[Constant.Constant.AkId];
            Weapon.gameObject.SetActive(true);
        }

        public void SelectPreviousWeapon()
        {
            _currentWeapon--;

            if (_currentWeapon < 0)
                _currentWeapon = _weapons.Count - 1;
            
            Weapon.gameObject.SetActive(false);
            
            SetActiveWeapon();
        }
        
        public void SelectNextWeapon()
        {
            _currentWeapon++;

            if (_currentWeapon >= _weapons.Count)
                _currentWeapon = 0;

            Weapon.gameObject.SetActive(false);
            
            SetActiveWeapon();
        }

        private void SetActiveWeapon()
        {
            OldWeaponSwitched?.Invoke(Weapon);
            
            Weapon = _weapons[_currentWeapon];
            Weapon.gameObject.SetActive(true);
            
            ChoosedWeapon?.Invoke(Weapon);
        }

        public void FillList( List<Weapon> weapons)
        {
            foreach (var weapon in weapons)
            {
                _weapons.Add(weapon);
            }
        }
    }
}