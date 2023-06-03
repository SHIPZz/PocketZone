using System;
using Services;
using Services.DependencyContainer;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 axis)
        {
            _rigidbody2D.transform.Translate(axis * Time.deltaTime);
        }

        private void OnVerticalMoved(float obj)
        {
            obj /= 2;
            
            _rigidbody2D.transform.Translate(obj * Time.deltaTime * Vector3.up);
        }

        private void OnHorizontalMoved(float obj)
        {
            _rigidbody2D.transform.Translate(obj * Time.deltaTime * Vector3.right);
        }
    }
}