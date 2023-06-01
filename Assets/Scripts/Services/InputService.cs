using System;
using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    public class InputService
    {
        private string _horizontal = "Horizontal";
        private string _vertical = "Vertical";
        private string _fire = "Fire";


        public Vector2 GetAxis() => 
            new(SimpleInput.GetAxis(_horizontal), SimpleInput.GetAxis(_vertical));

        public bool IsAttackInvoked() =>
            SimpleInput.GetButtonUp(_fire);
    }
}