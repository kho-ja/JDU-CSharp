// C# fanidan 8-amaliy topshiriq.
// Mavzu: Sinflarda xususiyatlar, indeksatorlar, statik usullar
// Ishning maqsadi: Talabalarda sinflarda xususiyatlar,
// indeksatorlar va statik usullardan foydalanish haqida bilim va
// ko'nikmalarini o'rgatishdan iborat.
// Bajariladigan vazifalar:
// 1. Sinf (class) yarating, unda 3 ta maydon yarating va har bir
// maydon uchun xususiyatlarni hosil qiling. Xususiyatlarni
// obyektlar massivi orqali foydalanib qiymatlar kiriting va natijalarni
// xususiyatlar vositasida chiqaring. Xususiyatlarning set va get
// metodlarini tushuntiring.
// 2. Sinf yarating, unda namunalarni sanash uchun indeksator hosil
// qiling. Namunalar massivini qiymatlang va indeksatorlardan
// foydalanib ularning qiymatlarini ekranga chiqaring.
// 3. Sinf maydonlari, xususiyatlari va usullarining farqini tushuntirib
// bering.
// 4. Statik sinf yarating uni ishlatilishini tushuntirib bering.
// 5. Sinfning statik a'zolarini yarating, masalan statik maydonlar,
// statik konstruktorlar, statik usullar. Loyihangizda ulardan
// foydalanishni ko'rsatib bering.

Console.WriteLine("Lesson 08 - Properties, Indexers, Static Methods");
Console.WriteLine("-------- 1. Xususiyatlar (Properties) --------");
Console.WriteLine("get - xususiyat qiymatini olish, set - xususiyat qiymatini berish.");
Console.WriteLine("set orqali qiymat tekshiruvlari/cheklovlari qo'yish mumkin.");
Console.WriteLine();

var products = new Product[3];
products[0] = new Product { Name = "Laptop", Price = 7500m, Quantity = 5 };
products[1] = new Product { Name = "Phone", Price = 3200m, Quantity = 12 };
products[2] = new Product { Name = "Notebook", Price = 25m, Quantity = 100 };

for (var i = 0; i < products.Length; i++)
{
    Console.WriteLine($"Mahsulot {i + 1}: {products[i].Name}, Narx: {products[i].Price}, Soni: {products[i].Quantity}");
}

Console.WriteLine();
Console.WriteLine("-------- 2. Indeksator --------");
var samples = new SampleCollection(4);
samples[0] = "A";
samples[1] = "B";
samples[2] = "C";
samples[3] = "D";

for (var i = 0; i < samples.Count; i++)
{
    Console.WriteLine($"Namuna[{i}] = {samples[i]}");
}

Console.WriteLine();
Console.WriteLine("-------- 3. Maydon, xususiyat va usul farqi --------");
Console.WriteLine("Maydon (field) - sinf ichida ma'lumot saqlaydi.");
Console.WriteLine("Xususiyat (property) - maydonga boshqariladigan kirish/chiqishni beradi.");
Console.WriteLine("Usul (method) - sinfning xatti-harakati yoki amali.");

Console.WriteLine();
Console.WriteLine("-------- 4. Statik sinf --------");
Console.WriteLine($"10 C -> {TemperatureConverter.CelsiusToFahrenheit(10)} F");
Console.WriteLine($"50 F -> {TemperatureConverter.FahrenheitToCelsius(50)} C");
Console.WriteLine("Statik sinfga obyekt yaratilmaydi, faqat nomi orqali chaqiriladi.");

Console.WriteLine();
Console.WriteLine("-------- 5. Statik a'zolar --------");
Ticket.ResetCounter(2000);
var t1 = new Ticket("Ali");
var t2 = new Ticket("Sami");
t1.Print();
t2.Print();
Console.WriteLine($"Jami berilgan chiptalar: {Ticket.IssuedCount}");

public class Product
{
    private string _name = string.Empty;
    private decimal _price;
    private int _quantity;

    public string Name
    {
        get => _name;
        set => _name = value ?? string.Empty;
    }

    public decimal Price
    {
        get => _price;
        set => _price = value < 0 ? 0 : value;
    }

    public int Quantity
    {
        get => _quantity;
        set => _quantity = value < 0 ? 0 : value;
    }
}

public class SampleCollection
{
    private readonly string[] _items;

    public SampleCollection(int size)
    {
        _items = new string[size];
    }

    public int Count => _items.Length;

    public string this[int index]
    {
        get => _items[index];
        set => _items[index] = value ?? string.Empty;
    }
}

public static class TemperatureConverter
{
    public static double CelsiusToFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public static double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }
}

public class Ticket
{
    private static int _nextNumber;

    public static int IssuedCount { get; private set; }

    public int Number { get; }
    public string Owner { get; }

    static Ticket()
    {
        _nextNumber = 1000;
        IssuedCount = 0;
    }

    public Ticket(string owner)
    {
        Owner = owner;
        Number = _nextNumber++;
        IssuedCount++;
    }

    public void Print()
    {
        Console.WriteLine($"Chiptaning egasi: {Owner}, Raqami: {Number}");
    }

    public static void ResetCounter(int startNumber)
    {
        _nextNumber = startNumber;
        IssuedCount = 0;
    }
}
