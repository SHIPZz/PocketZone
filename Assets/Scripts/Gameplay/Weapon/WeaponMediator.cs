using System;
using Gameplay.Player;
using Services;
using UnityEngine;

namespace Gameplay.Weapon
{
    [RequireComponent(typeof(WeaponSelectorHandler))]
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
            _weaponSelectorHandler.ChoosedWeapon += SetWeapon;
        }

        private void OnDisable() =>
            _weaponSelectorHandler.ChoosedWeapon -= SetWeapon;

        private void BulletQuantityChanged(int count) =>
            _count = count;

        private void SetWeapon(Weapon weapon) =>
                _weapon = weapon;

        public void SetPlayerAttacker(PlayerAttacker playerAttacker) =>
                _playerAttacker = playerAttacker;
    }
}