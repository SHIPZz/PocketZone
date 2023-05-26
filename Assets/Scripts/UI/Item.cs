
public class Item
{
    public  int Price { get; private set; }
    public  string Name { get; private set; }

    public Item(int price, string name)
    {
        Price = price;
        Name = name;
    }
}
