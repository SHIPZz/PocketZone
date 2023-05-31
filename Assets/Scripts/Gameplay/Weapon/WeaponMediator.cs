using System;
using Gameplay.Player;
using Services;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class WeaponMediator : MonoBehaviour
    {
        private PlayerAttacker _playerAttacker;
        private WeaponSelectorHandler _weaponSelectorHandler;
        private Weapon _weapon;
        
        private int _count;

        private void Awake()
        {
            _weaponSelectorHandler = GetComponent<WeaponSelectorHandler>();

            _weapon = _weaponSelectorHandler.Weapon;
        }

        private void Start()
        {
            _count = _weapon.BulletQuantity;
        }

        private void OnEnable()
        {
            _playerAttacker.Detected += OnDetected;
            _weaponSelectorHandler.ChoosedWeapon += SetWeapon;
        }
        
        private void OnDisable()
        {
            _weaponSelectorHandler.ChoosedWeapon -= SetWeapon;
            _playerAttacker.Detected -= OnDetected;
        }
        
        private void OnDetected(Vector3 direction)
        {
            _weapon.Shoot(direction);
        }

        private void BulletQuantityChanged(int count)
        {
            _count = count;
        }

        private void SetWeapon(Weapon weapon) =>
            _weapon = weapon;
        
        public void SetPlayerAttacker(PlayerAttacker playerAttacker) =>
            _playerAttacker = playerAttacker;
    }
}