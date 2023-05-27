namespace UI
{
    public class InventoryPresenter
    {
        private InventoryView _view;
        private Inventory _inventory;

        public InventoryPresenter(InventoryView view)
        {
            _view = view;
            _inventory = new Inventory();
            
            _inventory.OnItemAdded += OnItemAdded;
            _inventory.OnItemRemoved += OnItemRemoved;
        }

        public void AddItemToInventory(Item item)
        {
            _inventory.AddItem(item);
        }

        public void RemoveItemFromInventory(Item item)
        {
            _inventory.RemoveItem(item);
        }

        private void OnItemAdded(Item item)
        {
            // _view.AddToLayoutGroup(item);
        }

        private void OnItemRemoved(Item item)
        {
            // _view.RemoveFromLayoutGroup(item);
        }
    }
}