using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Weapon.Weapon _weapon;

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
                _weapon.Shoot(targetPoint);
            }
        }
    }
}
