using Gameplay;
using Gameplay.Health;
using UnityEngine;

namespace UI.Health
{
    public class HealthPresenter
    { 
        private readonly HealthView _healthView;
        private readonly IHealth _health;
        private readonly Character _character;

        public HealthPresenter(HealthView healthView, Character character)
        {
            _health = character.Health;
            _healthView = healthView;
            _character = character;

            _healthView.SetMaxValue(_health.CurrentValue);
            _health.ValueChanged += OnValueChanged;
            _character.TransformChanged += OnTransformChanged;
            _health.ValueZeroReached += OnHealthZeroReached;
        }
        
        ~HealthPresenter()
        {
            _health.ValueChanged -= OnValueChanged;
            _health.ValueZeroReached -= OnHealthZeroReached;
            _character.TransformChanged -= OnTransformChanged;
        }
        
        private void OnHealthZeroReached()
        {
            _healthView.Demolish();
        }
        
        private void OnTransformChanged(Transform obj)
        {
            _healthView.SetTransformToFollow(obj);
        }

        private void OnValueChanged(int value)
        {
            _healthView.SetValue(value);
        }
    }
}