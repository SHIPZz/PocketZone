namespace UI
{
    public class Cell
    {
        public int Quantity { get; set; }
        public Item Item { get; set; }

        public Cell(Item item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }
    }
}