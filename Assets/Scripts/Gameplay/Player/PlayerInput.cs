using System;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public event Action MouseClicked;
        
        private Button _shootButton;

        private void OnEnable()
        {
            StartCoroutine(WaitForButtonAssignment());
        }
        
        private void OnDisable()
        {
            if (_shootButton != null)
            {
                _shootButton.onClick.RemoveListener(OnShootButtonClicked);
            }
        }

        private System.Collections.IEnumerator WaitForButtonAssignment()
        {
            while (_shootButton == null)
            {
                yield return null;
            }

            _shootButton.onClick.AddListener(OnShootButtonClicked);
        }
        
        private void OnShootButtonClicked()
        {
            MouseClicked?.Invoke();
        }

        public void SetShootButton(Button shootButton)
        {
            _shootButton = shootButton;
        }
    }
}