using System;
using System.Collections.Generic;
using UI;

public class Inventory
{
    public event Action<Item> OnItemAdded;
    public event Action<Item> OnItemRemoved;
    
    private List<Cell> _cells = new List<Cell>();

    public void AddItem(Item item)
    {
        bool itemAdded = false;

        for (int i = 0; i < _cells.Count; i++)
        {
            if (_cells[i] != null && _cells[i].Item.Name == item.Name)
            {
                _cells[i].Quantity++;
                itemAdded = true;
                break;
            }
        }

        if (!itemAdded)
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                if (_cells[i] == null)
                {
                    _cells[i] = new Cell(item, 1);
                    break;
                }
            }
        }
        
        OnItemAdded?.Invoke(item);
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            if (_cells[i] != null && _cells[i].Item.Name == item.Name)
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
        
        OnItemRemoved?.Invoke(item);
    }

}