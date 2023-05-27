using System.Collections.Generic;

namespace UI
{
    public class ItemDatabase
    {
        private static readonly Item item = new Item("", 0);

        public static List<Item> Items = new List<Item>()
        {
            item,
            item,
            item,
            item,
            item,
            item,
            item,
            item,
            item
        };
    }
}