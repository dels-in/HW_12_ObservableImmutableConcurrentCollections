namespace HW_12;

public class Customer
{
    private Shop _shop;
    private string _name;

    public Customer(string name)
    {
        _name = name;
    }

    private void OnItemChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            //не знаю, как вызвать имя предмета у e.NewItems[], чтобы его в консоль вывести
            case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                Console.WriteLine($"{_name}: увидел появление товара \"{e.NewItems[e.NewItems.Count - 1]}\"");
                break;
            case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                Console.WriteLine($"{_name}: увидел удаление товара \"{e.OldItems[0]}\"");
                break;
        }
    }

    public void Subscribe(Shop shop)
    {
        _shop = shop;
        _shop.Items.CollectionChanged += OnItemChanged;
        Console.WriteLine($"{_name}: подписался");
    }

    public void Unsubscribe()
    {
        _shop.Items.CollectionChanged -= OnItemChanged;
        Console.WriteLine($"{_name}: отписался");
    }
}