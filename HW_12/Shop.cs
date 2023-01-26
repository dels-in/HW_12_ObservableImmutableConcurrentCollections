using System.Collections.ObjectModel;

namespace HW_12;

public class Shop
{
    public readonly ObservableCollection<Item> Items = new ObservableCollection<Item>();

    public void Add(Item items)
    {
        Console.WriteLine();
        Console.WriteLine($"Магазин: добавляю товар \"{items.Name}\"");
        Items.Add(items);
    }
    
    public void Remove(Item items)
    {
        Console.WriteLine();
        Console.WriteLine($"Магазин: удаляю товар \"{items.Name}\"");
        Items.Remove(items);
    }
}

