using System;
using Services;
using Services.DependencyContainer;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private InputService _inputService;
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _inputService = ServiceLocator.Get<InputService>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            // _inputService.HorizontalMoved += OnHorizontalMoved;
            // _inputService.VerticalMoved += OnVerticalMoved;
        }

        private void OnDisable()
        {
            // _inputService.HorizontalMoved += OnHorizontalMoved;
            // _inputService.VerticalMoved += OnVerticalMoved;
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