using System.Collections.Concurrent;
using System.Collections.Immutable;
using HW_12;

//ConstCustomer();
Librarian();
//JackHouse();


void ConstCustomer()
{
    var shop = new Shop();

    var customer = new Customer("Покупатель_1");
    customer.Subscribe(shop);

    //не уверен, что вообще нужно запариваться с этим count.
    //Моя идея - постоянная последовательность Id без пропуска цифр, но что-то я перемудрил :D
    var count = 0;
    while (true)
    {
        Console.WriteLine("Нажмите А для добавления товара, D для его удаления или Х для выхода из программы");
        var key = Console.ReadKey().Key;
        switch (key)
        {
            case ConsoleKey.A:
                if (count == 0)
                {
                    count++;
                    var itemToAdd = new Item(count, "Товар от: " + DateTime.Now);
                    shop.Add(itemToAdd);
                }
                else
                {
                    foreach (var item in shop.Items)
                    {
                        if (item.Id != count)
                        {
                            var itemToAdd = new Item(count, "Товар от: " + DateTime.Now);
                            shop.Add(itemToAdd);
                        }
                        else
                        {
                            var itemToAdd = new Item(shop.Items.Count() + 1, "Товар от: " + DateTime.Now);
                            shop.Add(itemToAdd);
                        }
                    }
                }

                break;
            case ConsoleKey.D:
                try
                {
                    if (count > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Введите ID товара для удаления");
                        int.TryParse(Console.ReadLine(), out int idToRemove);
                        var itemToFind = new Item(idToRemove, "");
                        foreach (var itemToRemove in shop.Items)
                        {
                            if (itemToRemove.Id == itemToFind.Id)
                            {
                                shop.Remove(itemToRemove);
                            }
                            else
                            {
                                Console.WriteLine();
                                var ex = new Exception("Товары отстутствуют в магазине");
                                throw ex;
                            }
                        }

                        count--;
                    }
                    else
                    {
                        Console.WriteLine();
                        var ex = new Exception("Товары отстутствуют в магазине");
                        throw ex;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                break;
            case ConsoleKey.X:
                return;
        }
    }
}

void Librarian()
{
    var concDict = new ConcurrentDictionary<string, int>();
    var flag = true;
    
    //спустя часы тренировок, понял, ято для ожидания именно в таске нужно указывать "async",
    //а перед "Task.Delay()" - "await". Я рад, что все-таки пришел к правильному ответу)
    Task.Run(async () =>
    {
        while (flag)           
        {
            await Task.Delay(1000);
            foreach (var book in concDict)
            {
                var currentValue = book.Value;
                if (book.Value < 100)
                {
                    concDict.TryUpdate(book.Key, currentValue + 1, currentValue);
                }
                else
                {
                    concDict.TryRemove(book.Key, out _);
                }
            }
        }
    });

    while (flag)
    {
        Console.WriteLine(
            "Введите 1 для добавления книги, " +
            "2 для просмотра списка непрочитанного " +
            "или 3 для выхода из программы");
        int.TryParse(Console.ReadLine(), out var number);
        switch (number)
        {
            case 1:
                Console.WriteLine("Введите название книги: ");
                var name = Console.ReadLine();
                if (name != null) concDict.TryAdd(name, 0);
                break;
            case 2:
                foreach (var book in concDict)
                {
                    Console.WriteLine(book.Key + " - " + book.Value + "%");
                }
                Console.ReadKey();
                break;
            case 3:
                flag = false;
                break;
        }
    }

    Console.ReadKey();
}

void JackHouse()
{
    var start = new List<string>(new[] { "Вот дом," }).ToImmutableList();
    var part1 = new Part1(start);
    part1.AddPart(start);
    var part2 = new Part2(part1.AddPart(start));
    var part3 = new Part3(part2.AddPart(part2.Poem));
    var part4 = new Part4(part3.AddPart(part3.Poem));
    var part5 = new Part5(part4.AddPart(part4.Poem));
    var part6 = new Part6(part5.AddPart(part5.Poem));
    var part7 = new Part7(part6.AddPart(part6.Poem));
    var part8 = new Part8(part7.AddPart(part7.Poem));
    var part9 = new Part9(part8.AddPart(part8.Poem));

    foreach (var str in part9.AddPart(part9.Poem))
    {
        Console.WriteLine(str);
    }
    //Console.WriteLine(part1.AddPart(part1.Poem));
}