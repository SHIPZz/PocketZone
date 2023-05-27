using System;
using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    public class WeaponSelectorInput : MonoBehaviour
    {
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;

        private WeaponSelectorHandler _weaponSelectorHandler;

        private void Awake()
        {
            _weaponSelectorHandler = GetComponent<WeaponSelectorHandler>();
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
            _weaponSelectorHandler.SelectPreviousWeapon();
        }
        
        private void OnRightButtonClicked()
        {
            _weaponSelectorHandler.SelectNextWeapon();
        }
    }
}