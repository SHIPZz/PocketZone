using System;
using Services;
using UnityEngine;

namespace Gameplay.Player
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;

        public event Action<Vector3> Detected;
        
        private readonly int _maxAngle = 90;

        private Weapon.Weapon _weapon;
        private float _radius;
        private PlayerInput _playerInput;
        private Vector3 _direction;
        private WeaponSelectorHandler _weaponSelectorHandler;

        private void Awake()
        {
            var cirlceCollider2D = GetComponent<CircleCollider2D>();
            _radius = cirlceCollider2D.radius;
            cirlceCollider2D.enabled = false;
            _weapon = _weaponSelectorHandler?.Weapon;
        }

        private void OnEnable()
        {
            _weaponSelectorHandler.ChoosedWeapon += SetWeapon;
            // _playerInput.MouseClicked += Attack;
        }

        private void OnDisable()
        {
            // _playerInput.MouseClicked -= Attack;
            _weaponSelectorHandler.ChoosedWeapon -= SetWeapon;
        }

        private void Update()
        {
            if(_weapon == null)
                return;
            
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);
            
            foreach (var hitCollider in hitColliders)
            {
                var direction = hitCollider.transform.position - _weapon.transform.position;
                _weapon.transform.right = direction;

                _direction = hitCollider.transform.position;

                if (Mathf.Abs(Vector2.Angle(Vector2.right, _weapon.transform.right)) > _maxAngle)
                {
                    _weapon.transform.localScale = new Vector3(1,-1,1);
                }
                else
                {
                    _weapon.transform.localScale = Vector3.one;
                }
                
                return;
            }

            _weapon.transform.localScale = Vector3.one;
            _weapon.transform.right = Vector3.right;
            _direction = Vector3.zero;
        }

        public void SetPlayerInput(PlayerInput playerInput) =>
            _playerInput = playerInput;

        public void SetWeaponSelectorHandler(WeaponSelectorHandler weaponSelectorHandler) =>
            _weaponSelectorHandler = weaponSelectorHandler;

        private void SetWeapon(Weapon.Weapon weapon) =>
            _weapon = weapon;
        
        private void Attack()
        {
            if (_direction == Vector3.zero || _direction == Vector3.one)
                return;

            Detected?.Invoke(_direction);
            // _weapon.Shoot(_direction);
        }
    }
}