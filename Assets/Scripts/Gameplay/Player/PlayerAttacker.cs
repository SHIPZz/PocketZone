using System;
using UnityEngine;

namespace Gameplay.Player
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class PlayerAttacker : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Transform _gun;
        
        private float _radius;
        
        private void Awake()
        {
            var cirlceCollider2D = GetComponent<CircleCollider2D>();
            _radius = cirlceCollider2D.radius;
            cirlceCollider2D.enabled = false;
        }

        private void Update()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _radius, _layerMask);
            
            foreach (var hitCollider in hitColliders)
            {
                var direction = hitCollider.transform.position - _gun.position;
                _gun.right = direction;

                if (Mathf.Abs(Vector2.Angle(Vector2.right, _gun.right)) > 90)
                {
                    _gun.localScale = new Vector3(1,-1,1);
                }
                else
                {
                    _gun.localScale = Vector3.one;
                }
                
                return;
            }

            _gun.localScale = Vector3.one;
            _gun.right = Vector3.right;
        }
    }
}