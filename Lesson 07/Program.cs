// C# fanidan 7-amaliy topshiriq.
// Mavzu: Sinflar va obyektlar ustida amallar
// Ishning maqsadi: Talabalarda C# dasturlash tilida obyektga yo’naltirilgan
// dasturlash tamoyillari tushunchasi, sinflar va obyektlar ustida ishlash bilim va
// ko’nikmalarini o’rgatishdan iborat.
// Bajariladigan vazifalar:
// 1. Obyektga yo’naltirilgan dasturlash tamoyillari haqida tushunchangizni
// gapirib bering.
// 2. Yangi sinf (class) yarating (namuna uchun: computers, notebooks,
// phones, students, workers, universities, games, books va h.k.). Sinf
// maydonlari (fields) shakllantiring. Main metodida sinfdan obyekt
// yaratib, uni qiymatlang va natijani konsol iynasiga chiqaring.
// 3. Yangi sinf yarating, maydonlarini shakllantiring, bir nechta variantda
// konstruktorlarni ishlab chiqing va ulardan obyektlarni
// initsializatsiyalashda foydalaning.
// 4. Yangi sinf yarating, maydonlarini shakllantiring, qiymat kiritish va
// chiqarish metodlarini hosil qiling. Dasturning asosiy metodi (Main)da
// sinfdan obyekt yarating va metodlardan foydalaning.
// 5. Yangi sinf yarating, sinfda statik maydonlar va metodlarni hosil qiling,
// ulardan foydalanishni ko’rsatib bering.

Console.WriteLine("Lesson 07 - Classes and Objects");
Console.WriteLine("-------- 1. OOP Tamoyillari --------");
Console.WriteLine("Inkapsulyatsiya: ma’lumot va metodlarni sinf ichida yashirish.");
Console.WriteLine("Merosxo’rlik: mavjud sinf xususiyatlarini yangi sinfga o’tkazish.");
Console.WriteLine("Polimorfizm: bir xil interfeys orqali turli xil xatti-harakat.");
Console.WriteLine("Abstraksiya: ortiqcha tafsilotlarni yashirib, muhim qismini ko’rsatish.");
Console.WriteLine();

Console.WriteLine("-------- 2. Oddiy sinf --------");
var book = new Book
{
    Title = "C# Asoslari",
    Author = "Abdulaziz",
    Pages = 320
};
book.Print();
Console.WriteLine();

Console.WriteLine("-------- 3. Konstruktorlar --------");
var pc1 = new Computer();
var pc2 = new Computer("Dell", "Latitude");
var pc3 = new Computer("HP", "Pavilion", 16);
pc1.Print();
pc2.Print();
pc3.Print();
Console.WriteLine();

Console.WriteLine("-------- 4. Kiritish/chiqarish metodlari --------");
var worker = new Worker();
worker.ReadFromConsole();
worker.Print();
Console.WriteLine();

Console.WriteLine("-------- 5. Statik maydon va metod --------");
var card1 = new LibraryCard("Ali");
var card2 = new LibraryCard("Sami");
card1.Print();
card2.Print();
Console.WriteLine($"Jami berilgan kartalar: {LibraryCard.GetIssuedCount()}");

public class Book
{
    public string Title;
    public string Author;
    public int Pages;

    public void Print()
    {
        Console.WriteLine($"Kitob: {Title}");
        Console.WriteLine($"Muallif: {Author}");
        Console.WriteLine($"Sahifalar: {Pages}");
    }
}

public class Computer
{
    public string Brand;
    public string Model;
    public int RamGb;

    public Computer()
    {
        Brand = "Unknown";
        Model = "Unknown";
        RamGb = 4;
    }

    public Computer(string brand, string model)
    {
        Brand = brand;
        Model = model;
        RamGb = 8;
    }

    public Computer(string brand, string model, int ramGb)
    {
        Brand = brand;
        Model = model;
        RamGb = ramGb;
    }

    public void Print()
    {
        Console.WriteLine($"Kompyuter: {Brand} {Model}, RAM: {RamGb} GB");
    }
}

public class Worker
{
    public string FullName;
    public string Position;
    public double Salary;

    public void ReadFromConsole()
    {
        Console.Write("F.I.Sh. kiriting: ");
        FullName = Console.ReadLine() ?? string.Empty;

        Console.Write("Lavozim kiriting: ");
        Position = Console.ReadLine() ?? string.Empty;

        Salary = ReadDouble("Oylik maosh kiriting: ", 0, 1_000_000);
    }

    public void Print()
    {
        Console.WriteLine($"Xodim: {FullName}");
        Console.WriteLine($"Lavozim: {Position}");
        Console.WriteLine($"Maosh: {Salary}");
    }

    private static double ReadDouble(string prompt, double min, double max)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (double.TryParse(input, out var value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Iltimos, {min} va {max} oralig’ida qiymat kiriting.");
        }
    }
}

public class LibraryCard
{
    private static int issuedCount;

    public int CardNumber { get; }
    public string Owner { get; }

    public LibraryCard(string owner)
    {
        Owner = owner;
        CardNumber = GenerateNumber();
    }

    public void Print()
    {
        Console.WriteLine($"Karta egasi: {Owner}");
        Console.WriteLine($"Karta raqami: {CardNumber}");
    }

    public static int GetIssuedCount()
    {
        return issuedCount;
    }

    private static int GenerateNumber()
    {
        issuedCount++;
        return 1000 + issuedCount;
    }
}
