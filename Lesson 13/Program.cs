// C# fanidan 13-amaliy topshiriq.
// Mavzu: Fayllar bilan ishlash
// Ishning maqsadi: Talabalarga fayllar bilan ishlash uchun C# sinflari
// va ularning imkoniyatlari haqidagi bilim va ko'nikmalarini berishdan
// iborat.
// Bajariladigan vazifalar:
// 1. Loyihangiz joylashgan papkada yangi papka yarating va uning
// ichida yangi matnli fayl yarating. Yaratgan matnli faylingizga
// qandaydir matnli ma'lumotlar kiriting. Matnli faylga kiritilgan
// ma'lumotlarni konsol oynasiga chiqaring.
// 2. Tanlangan fayl haqidagi ma'lumotlarni (nomi, tipi, yo'li, hajmi,
// yaratilgan vaqti va h.k.) chiqarish dasturini tuzing.
// 3. Matnli faylga ma'lumotlarni yozish, qo'shish va ularni ekranga
// chop etish metodlarini alohida sinfda yarating.

Console.WriteLine("Lesson 13 - Working with Files");

var projectDir = ResolveProjectDirectory();
var workDir = Path.Combine(projectDir, "WorkData");
Directory.CreateDirectory(workDir);

var filePath = Path.Combine(workDir, "notes.txt");
var manager = new TextFileManager(filePath);

Console.WriteLine("-------- 1. Fayl yaratish va o'qish --------");
manager.Write("Bugun C# darsida fayllar bilan ishlashni o'rgandik.");
manager.Append(Environment.NewLine + "Matnli faylga ma'lumot yozish va qo'shish amaliyoti bajarildi.");
Console.WriteLine("Fayl mazmuni:");
Console.WriteLine(manager.ReadAll());
Console.WriteLine();

Console.WriteLine("-------- 2. Fayl ma'lumotlari --------");
var info = new FileInfo(filePath);
Console.WriteLine($"Nomi: {info.Name}");
Console.WriteLine($"Turi: {info.Extension}");
Console.WriteLine($"Yo'li: {info.FullName}");
Console.WriteLine($"Hajmi (bayt): {info.Length}");
Console.WriteLine($"Yaratilgan vaqti: {info.CreationTime}");
Console.WriteLine($"Oxirgi o'zgartirilgan: {info.LastWriteTime}");
Console.WriteLine();

Console.WriteLine("-------- 3. Sinf orqali yozish/qo'shish/o'qish --------");
manager.Append(Environment.NewLine + "TextFileManager sinfi orqali qo'shimcha satr yozildi.");
Console.WriteLine(manager.ReadAll());

static string ResolveProjectDirectory()
{
    var current = Directory.GetCurrentDirectory();
    var currentProject = Path.Combine(current, "Lesson 13.csproj");
    if (File.Exists(currentProject))
    {
        return current;
    }

    var nestedProjectDir = Path.Combine(current, "Lesson 13");
    var nestedProjectFile = Path.Combine(nestedProjectDir, "Lesson 13.csproj");
    if (File.Exists(nestedProjectFile))
    {
        return nestedProjectDir;
    }

    return current;
}

public class TextFileManager
{
    public string FilePath { get; }

    public TextFileManager(string filePath)
    {
        FilePath = filePath;
    }

    public void Write(string content)
    {
        File.WriteAllText(FilePath, content);
    }

    public void Append(string content)
    {
        File.AppendAllText(FilePath, content);
    }

    public string ReadAll()
    {
        return File.ReadAllText(FilePath);
    }
}
