using System.Collections.Generic;
using UI;

public class Inventory
{
    private readonly List<Cell> _cells = new List<Cell>();
    private int _count;

    public void AddItem(Item item)
    {
        bool itemAdded = false;

        for (int i = 0; i < _cells.Count; i++)
        {
            if (_cells[i] != null && _cells[i].Item.Equals(item))
            {
                _cells[i].Quantity++;
                itemAdded = true;
                break;
            }
        }

        if (itemAdded == false)
        {
            var cell = new Cell(item, 1);
            _cells.Add(cell);
        }
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            if (_cells[i] != null && _cells[i].Item.Equals(item))
            {
                if (_cells[i].Quantity > 1)
                {
                    _cells[i].Quantity--;
                }
                else
                {
                    _cells.RemoveAt(i);
                }
                break;
            }
        }
    }

}