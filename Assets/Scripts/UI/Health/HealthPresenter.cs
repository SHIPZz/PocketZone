using System;
using Gameplay;
using Gameplay.Health;
using UnityEngine;

namespace UI.Health
{
    public class HealthPresenter
    { 
        private HealthView _healthView;
        
        private IHealth _health;

        public HealthPresenter(HealthView healthView, IHealth health)
        {
            _healthView = healthView;
            _health = health;
            
            _healthView.SetMaxValue(_health.CurrentValue);
            _health.ValueChanged += OnValueChanged;
        }

        ~HealthPresenter()
        {
            _health.ValueChanged -= OnValueChanged;
        }

        private void OnValueChanged(int value)
        {
            _healthView.SetValue(value);
        }
    }
}