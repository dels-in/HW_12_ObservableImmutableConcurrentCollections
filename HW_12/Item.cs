using System.Security.Cryptography;

namespace HW_12;

public class Item
{
    
    private string _name;
    private int _id;

    //нарушил здесь инкапсуляцию, но по-другому не знаю, как в классе шоп передавать название items
    public string Name => _name;
    public int Id => _id;

    public Item(int id, string name )
    {
        _name = name;
        _id = id;
    }
}