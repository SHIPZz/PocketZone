
using UnityEngine.UI;

public struct Item
{
    public Item(string name, int price)
    {
        Name = name;
        Price = price;
        // Image = image;
    }

    public string Name { get; private set; }
    public int Price { get; private set; }
    // public Image Image { get; private set; }
}