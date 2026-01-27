// C# fanidan 9-amaliy topshiriq.
// Mavzu: Sinflarda vorislikga oid amallarni bajarish
// Ishning maqsadi: Talabalarning sinflarda vorislikga oid amallarni
// bajarish bilim va ko'nikmalarini o'zlashtirishidan iborat.
// Bajariladigan vazifalar:
// 1. 17-dars videosini so'ngida keltirilgan topshiriqni bajarish.
// 2. Nashrlar va Kitoblar sinfini yarating va ularda vorislik amaliyotini
// qo'llang. Ota sinf xususiyatlarni bola sinfda qo'llanilishini ko'rsatib
// bering.
// 3. Mustaqil ta'lim: Vorislikda 'base' kalit so'zini qo'llanilishini
// o'rganing va tushuntirib bering.
// 4. Mustaqil ta'lim: Vorislikda 'record' modifikatorining qo'llanilishiga
// oid misol ko'rsating.

Console.WriteLine("Lesson 09 - Inheritance");
Console.WriteLine("-------- 1. 17-dars videosi --------");
Console.WriteLine("Video topshirig'i matni berilmagan. 2-4-vazifalar bajarildi.");
Console.WriteLine();

Console.WriteLine("-------- 2. Nashrlar va Kitoblar (Inheritance) --------");
var publication = new Publication("JDU Journal", "JDU Press", 2024);
publication.Print();
Console.WriteLine();

var book = new Book("C# Asoslari", "JDU Press", 2023, "Abdulaziz", 420);
book.Print();
Console.WriteLine();

Console.WriteLine("-------- 3. base kalit so'zi --------");
Console.WriteLine("Base ota sinfning konstruktorini va a'zolarini chaqirish uchun ishlatiladi.");
var textbook = new Book("OOP Nazariyasi", "Akademiya", 2022, "Professor A", 350);
Console.WriteLine("Book konstruktori ichida base(...) orqali Publication konstruktori chaqirildi.");
textbook.Print();
Console.WriteLine();

Console.WriteLine("-------- 4. record modifikatori --------");
var recordPublication = new PublicationRecord("Tech Weekly", "Tashkent Media", 2025);
var recordBook = new BookRecord("C# Patterns", "Tashkent Media", 2025, "Nodir", 280);
Console.WriteLine(recordPublication);
Console.WriteLine(recordBook);
Console.WriteLine("record tiplari qiymat asosida tenglikni va qisqa yozuvni ta'minlaydi.");

public class Publication
{
    public string Title { get; }
    public string Publisher { get; }
    public int Year { get; }

    public Publication(string title, string publisher, int year)
    {
        Title = title;
        Publisher = publisher;
        Year = year;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Nashr: {Title}");
        Console.WriteLine($"Nashriyot: {Publisher}");
        Console.WriteLine($"Yil: {Year}");
    }
}

public class Book : Publication
{
    public string Author { get; }
    public int Pages { get; }

    public Book(string title, string publisher, int year, string author, int pages)
        : base(title, publisher, year)
    {
        Author = author;
        Pages = pages;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Muallif: {Author}");
        Console.WriteLine($"Sahifalar: {Pages}");
    }
}

public record PublicationRecord(string Title, string Publisher, int Year);

public record BookRecord(string Title, string Publisher, int Year, string Author, int Pages)
    : PublicationRecord(Title, Publisher, Year);
