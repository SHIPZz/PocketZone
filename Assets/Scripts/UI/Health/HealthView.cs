using System;
using Gameplay;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Health
{
    public class HealthView : MonoBehaviour
    {
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public void SetMaxValue(int value)
        {
            _slider.maxValue = value;
            _slider.value = value;
        }

        public void SetValue(int value)
        {
            _slider.value = value;
        }

        public void SetTransformToFollow(Transform transform)
        {
            if (transform != null || transform.IsDestroyed() == false)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                gameObject.transform.parent.position = screenPos + Vector3.up * 20f;
            }
        }

        public void Demolish()
        {
            gameObject.SetActive(false);
        }
    }
}