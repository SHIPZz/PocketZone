using System;
using System.Collections.Generic;
using Extensions.GameObjectExtension;
using Gameplay.Weapon;
using UnityEngine;

namespace Services
{
    public class WeaponSelectorHandler : MonoBehaviour
    {
         private List<Weapon> _weapons = new List<Weapon>();
        
        public event Action<Weapon> ChoosedWeapon;
        public event Action<Weapon> OldWeaponSwitched; 

        private Weapon _weapon;
        private int _currentWeapon = 0;

        public IReadOnlyList<Weapon> Weapons =>
            _weapons;

        public Weapon Weapon =>
            _weapon;

        private void Start()
        {
            _weapon = _weapons[Constant.Constant.AkId];
            _weapon.gameObject.SetActive(true);
        }

        public void SelectPreviousWeapon()
        {
            _currentWeapon--;

            if (_currentWeapon < 0)
                _currentWeapon = _weapons.Count - 1;
            
            _weapon.gameObject.SetActive(false);
            
            SetActiveWeapon();
        }
        
        public void SelectNextWeapon()
        {
            _currentWeapon++;

            if (_currentWeapon >= _weapons.Count)
                _currentWeapon = 0;

            _weapon.gameObject.SetActive(false);
            
            SetActiveWeapon();
        }

        private void SetActiveWeapon()
        {
            OldWeaponSwitched?.Invoke(_weapon);
            
            _weapon = _weapons[_currentWeapon];
            _weapon.gameObject.SetActive(true);
            
            ChoosedWeapon?.Invoke(_weapon);
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