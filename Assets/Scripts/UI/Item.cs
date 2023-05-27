
public struct Item
{
    public Item(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public string Name { get; private set; }
    public int Price { get; private set; }
}
