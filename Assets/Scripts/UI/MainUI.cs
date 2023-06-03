using UnityEngine;

namespace UI
{
    public class MainUI : MonoBehaviour
    { 
        [field: SerializeField] public BulletQuantityMediator BulletQuantityMediator { get; private set; }
        [field: SerializeField] public InventoryView InventoryView { get; private set; }
    }
}