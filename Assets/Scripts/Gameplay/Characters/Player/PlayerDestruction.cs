using System;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerDestruction : MonoBehaviour
    {
        private Player _player;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void OnEnable()
        {
            _player.Health.ValueZeroReached += OnValueZeroReached;
        }
        
        private void OnDisable()
        {
            _player.Health.ValueZeroReached -= OnValueZeroReached;
        }
        
        private void OnValueZeroReached()
        {
            Destroy(gameObject);
        }
    }
}