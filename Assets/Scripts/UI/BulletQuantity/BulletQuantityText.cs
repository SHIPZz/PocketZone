using System;
using Gameplay.Weapon;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class BulletQuantityText : MonoBehaviour
    {
        public TextMeshProUGUI Text { get; private set; }
        public Weapon Weapon { get; set; }

        private void Awake()
        {
            Text = GetComponent<TextMeshProUGUI>();
        }

        private void Update()
        {
            // Text.text = Weapon.BulletQuantity.ToString();
        }

        public void Set(int count) =>
            Text.text = count.ToString();
    }
}