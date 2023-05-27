using System;
using System.Collections.Generic;
using Gameplay.Weapon;
using UnityEngine;

namespace Services
{
    public class WeaponSelectorHandler : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons = new List<Weapon>();

        public event Action<Weapon> ChoosedWeapon;

        private Weapon _weapon;
        private int _currentWeapon = 0;

        private void Start()
        {
            _weapon = _weapons[Constant.Constant.AkId];
            _weapon.gameObject.SetActive(true);
            ChoosedWeapon?.Invoke(_weapon);
        }

        public void SelectPreviousWeapon()
        {
            _currentWeapon--;

            if (_currentWeapon < 0)
                _currentWeapon = _weapons.Count - 1;
            
            _weapon.gameObject.SetActive(false);
            
            SetActiveWeapon();
            
            ChoosedWeapon?.Invoke(_weapon);
        }
        
        public void SelectNextWeapon()
        {
            _currentWeapon++;

            if (_currentWeapon >= _weapons.Count)
                _currentWeapon = 0;

            _weapon.gameObject.SetActive(false);
            
            SetActiveWeapon();
            
            ChoosedWeapon?.Invoke(_weapon);
        }

        private void SetActiveWeapon()
        {
            _weapon = _weapons[_currentWeapon];
            _weapon.gameObject.SetActive(true);
        }
    }
}