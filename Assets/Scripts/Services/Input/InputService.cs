using UnityEngine;

namespace Services
{
    public class InputService
    {
        private string _horizontal = "Horizontal";
        private string _vertical = "Vertical";
        private string _fire = "Fire";
        private string _nextWeapon = "NextWeapon";
        private string _previousWeapon = "PreviousWeapon";
        private string _openInventory = "OpenInventory";
        private string _closeInventory = "CloseInventory";
        private string _reloadWeapon = "Reload";

        public Vector2 GetAxis() => 
            new(SimpleInput.GetAxis(_horizontal), SimpleInput.GetAxis(_vertical));

        public bool IsAttackInvoked() =>
            SimpleInput.GetButtonUp(_fire);

        public bool IsNextWeaponInvoked() =>
            SimpleInput.GetButtonUp(_nextWeapon);

        public bool IsPreviousWeaponInvoked() =>
            SimpleInput.GetButtonUp(_previousWeapon);

        public bool IsInventoryOpened() =>
            SimpleInput.GetButtonUp(_openInventory);
        
        public bool IsInventoryClosed() =>
            SimpleInput.GetButtonUp(_closeInventory);
        
        public bool IsReloaded() =>
            SimpleInput.GetButtonUp(_reloadWeapon);

    }
}