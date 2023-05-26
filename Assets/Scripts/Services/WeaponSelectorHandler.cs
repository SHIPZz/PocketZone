using System;
using System.Collections.Generic;
using Gameplay.Weapon;
using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    public class WeaponSelectorHandler : MonoBehaviour
    {
        [SerializeField] private List<Weapon> _weapons = new List<Weapon>();
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;

        public event Action<Weapon> ChoosedWeapon;

        private Weapon _weapon;
        private int _currentWeapon = 0;

        private void Start()
        {
            _weapon = _weapons[Constant.Constant.AkId];
            _weapon.gameObject.SetActive(true);
            ChoosedWeapon?.Invoke(_weapon);
        }

        private void OnEnable()
        {
            _leftButton.onClick.AddListener(OnLeftButtonClicked);
            _rightButton.onClick.AddListener(OnRightButtonClicked);
        }

        private void OnDisable()
        {
            _leftButton.onClick.RemoveListener(OnLeftButtonClicked);
            _rightButton.onClick.RemoveListener(OnRightButtonClicked);
        }
        
        private void OnLeftButtonClicked()
        {
            _currentWeapon--;

            if (_currentWeapon < 0)
                _currentWeapon = _weapons.Count - 1;
            
            _weapon.gameObject.SetActive(false);
            
            SetActiveWeapon();
            
            ChoosedWeapon?.Invoke(_weapon);
        }
        
        private void OnRightButtonClicked()
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