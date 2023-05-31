using System;
using Gameplay;
using Gameplay.Health;
using UnityEngine;

namespace UI.Health
{
    public class HealthPresenter : MonoBehaviour
    { 
        private HealthView _healthView;
        
        private ICharacter _character;
        private IHealth _health;

        private void Start()
        {
            _healthView.SetMaxValue(_health.CurrentValue);
        }
        
        private void OnEnable()
        {
            _health.ValueChanged += OnValueChanged;
        }
        
        private void OnDisable()
        {
            _health.ValueChanged -= OnValueChanged;
        }

        public void SetHealthView(HealthView healthView) =>
            _healthView = healthView;
        
        public void SetCharacter(ICharacter character) =>
            _character = character;
        
        public void SetHealth(IHealth health) =>
            _health = health;
        
        private void OnValueChanged(int value)
        {
            _healthView.SetValue(value);
        }
    }
}