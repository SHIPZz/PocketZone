using System;
using UnityEngine;

namespace Services
{
    public class InputService : IUpdateable
    {
        public event Action<float> HorizontalMoved;
        public event Action<float> VerticalMoved;

        private string _horizontal = "Horizontal";
        private string _vertical = "Vertical";

        public void Update()
        {
            HorizontalMoved?.Invoke(SimpleInput.GetAxis(_horizontal));
            VerticalMoved?.Invoke(SimpleInput.GetAxis(_vertical));
        }
    }
}