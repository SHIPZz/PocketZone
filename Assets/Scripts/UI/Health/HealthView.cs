using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Health
{
    public class HealthView : MonoBehaviour
    {
        public event Action<int> ValueChanged; 

        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        public void SetMaxValue(int value) =>
            _slider.maxValue = value;

        public void SetValue(int value)
        {
            _slider.value = value;
        }
    }
}