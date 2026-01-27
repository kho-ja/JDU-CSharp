// C# fanidan 11-amaliy topshiriq.
// Mavzu: Polimorfizm
// Ishning maqsadi: Talabalarga polimorfizm tamoyilidan
// foydalangan holda sinflarni modifikatsiyalash bilim va
// ko'nikmalarini o'rgatishdan iborat.
// Bajariladigan vazifalar:
// 1. Tanlangan masala (class) bo'yicha polimorfizm tamoyilidan
// foydalangan holda, sinf ichida bir xil nomli usullarni
// (metodlarni) hosil qiling va ularning ishlatilishini tahlil qiling.
// 2. Tanlangan sinfda virtual usullarni yarating va ularni voris sinfda
// qayta aniqlang (override). Bu usullardan foydalanishni ko'rsatib
// bering.

Console.WriteLine("Lesson 11 - Polymorphism");
Console.WriteLine("-------- 1. Overload (bir xil nomli metodlar) --------");
var calculator = new Calculator();
Console.WriteLine($"Add(int, int) = {calculator.Add(3, 7)}");
Console.WriteLine($"Add(double, double) = {calculator.Add(2.5, 4.1)}");
Console.WriteLine($"Add(int, int, int) = {calculator.Add(1, 2, 3)}");
Console.WriteLine();

Console.WriteLine("-------- 2. Virtual/Override --------");
MediaItem baseItem = new MediaItem("Umumiy nashr", 2020);
MediaItem book = new BookItem("C# OOP", 2023, "Abdulaziz");
MediaItem magazine = new MagazineItem("Tech Weekly", 2024, 12);

baseItem.PrintInfo();
book.PrintInfo();
magazine.PrintInfo();
Console.WriteLine();

Console.WriteLine("Polimorfizm: MediaItem turidagi o'zgaruvchilar orqali turli voris sinflar");
Console.WriteLine("PrintInfo metodini o'ziga xos tarzda bajaradi.");

public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }
}

public class MediaItem
{
    public string Title { get; }
    public int Year { get; }

    public MediaItem(string title, int year)
    {
        Title = title;
        Year = year;
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Nashr: {Title}, Yil: {Year}");
    }
}

public class BookItem : MediaItem
{
    public string Author { get; }

    public BookItem(string title, int year, string author)
        : base(title, year)
    {
        Author = author;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Kitob: {Title}, Muallif: {Author}, Yil: {Year}");
    }
}

public class MagazineItem : MediaItem
{
    public int IssueNumber { get; }

    public MagazineItem(string title, int year, int issueNumber)
        : base(title, year)
    {
        IssueNumber = issueNumber;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Jurnal: {Title}, Son: {IssueNumber}, Yil: {Year}");
    }
}
