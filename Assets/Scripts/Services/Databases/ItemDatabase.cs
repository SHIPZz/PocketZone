using System.Collections.Generic;

namespace UI
{
    public class ItemDatabase
    {
        private static readonly Item item = new Item("", 0);

        public static List<Item> Items = new List<Item>()
        {
            new Item("Советская бутылка", 100),
            new Item("Советская бутылка", 200),
            item,
            item,
            item,
            item,
            item,
            item,
            item,
            item
        };

        public static Item GetItem(int id) =>
            Items[id];
    }
}