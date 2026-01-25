// C# fanidan 4-amaliy topshiriq.
// Mavzu: C# dasturlash tilida massivlar va kolleksiyalar bilan ishlash
// Ishning maqsadi: Talabalarga C# dasturlash tilida massivlar va kolleksiyalar
// bilan ishlash ko’nikmalarni o‘rgatishdan iborat.
// Bajariladigan vazifalar:
// 1. 𝑎 = {24, 5, 16, 9, 37, 28, 4, 32} massivi berilgan. Uning elementlari
// miqdorini, minimumini, maxsimumini, o’rtacha qiymatini va summasini
// hisoblash dasturini tuzing.
// 2. Haqiqiy qiymatlardan iborat 10 ta tasodifiy elementli R massivni hosil
// qiling. Uning o’rtacha qiymatidan kichiklarini 0 soniga, kattalarini 1
// soniga tenglashtirib yangi K massivga yozing. K massivda nechta 0
// va nechta 1 sonlarini borligini aniqlash dasturini tuzing.
// 3. Ikki o’lchovli (4x3) massiv hosil qiling va uning elementlari qiymatlarini
// klaviaturadan kiritish ta’minlansin. Uning qatorlaridagi qiymatlarini
// ustunlarga quyidagi ko’rinishda akstantirilsin:
// 4. Qiymatlari so’zlardan iborat List<T> obyektini yarating. Unga yangi
// element qo’shish, elementni o’chirish, ko’rsatilgan indeksga yangi
// elementni qo’yish, element mavjudligini tekshirish kabi vazifalarni
// dasturlash orqali amalga oshiring.
// 5. O’zbekcha-inglizcha, o’zbekcha-yaponcha, o’zbekcha-ruzcha yoki
// o’zingizni qiziqtirgan boshqa tillarda Dictionary<TKey,TValue>
// sinfidan foydalanib kichik lug’at dasturini yarating.
// 6. 𝑎 = {24, 5, 16, 9, 37, 28, 4, 32} massiv elementlarini Queue, Stack
// va HashSet sinfi obyektlarini yaratib ularning elementlari sifatida
// kiriting. Natijalarni ekranga chiqaring.

// Misol 1.
Console.WriteLine("-------- Misol 1 --------");
int[] a = { 24, 5, 16, 9, 37, 28, 4, 32 };

Console.WriteLine($"a: {string.Join(", ", a)}");
Console.WriteLine($"Elementlar soni: {a.Length}");
Console.WriteLine($"Minimum: {a.Min()}");
Console.WriteLine($"Maksimum: {a.Max()}");
Console.WriteLine($"O'rtacha qiymat: {a.Average()}");
Console.WriteLine($"Elementlar yig'indisi: {a.Sum()}");

// Misol 2.
Console.WriteLine("-------- Misol 2 --------");
Random rand = new Random();
double[] R = new double[10];
for (int i = 0; i < R.Length; i++)
{
    R[i] = Math.Floor(rand.NextDouble() * 100); // 0 dan 100 gacha bo'lgan haqiqiy sonlar
}
Console.WriteLine($"R: {string.Join(", ", R)}");

double avarage = R.Average();
for (int i = 0; i < R.Length; i++)
{
    R[i] = R[i] < avarage ? 0 : 1;
}
Console.WriteLine($"R: {string.Join(", ", R)}");
Console.WriteLine($"Avarage: {avarage}");

// Misol 3.
Console.WriteLine("-------- Misol 3 --------");
int[,] matrix = new int[4, 3];
for (int i = 0; i < 4; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write($"matrix[{i},{j}] ni kiriting: ");
        string prompt = Console.ReadLine() ?? "";
        matrix[i, j] = int.Parse(prompt);
    }
}

Console.WriteLine("Matrix:");
// Qatorlarni ustunlarga aksantirish
for (int j = 0; j < 3; j++)
{
    for (int i = 0; i < 4; i++)
    {
        Console.Write($"{matrix[i, j]} |");
    }
    Console.WriteLine("\n-------------");
}

// Teskari tartibda chiqarish
Console.WriteLine("Teskari tartibda:");
for (int i = 0; i < 4; i++)
{
    for (int j = 2; j >= 0; j--)
    {
        Console.Write($"{matrix[i, j]} |");
    }
    Console.WriteLine("\n-------------");
}


// Misol 4.
Console.WriteLine("-------- Misol 4 --------");
List<string> words = new List<string> { "olma", "banan", "anor" };
// Element qo'shish
words.Add("shaftoli");
// Element o'chirish
words.Remove("banan");
// Indeksga yangi element qo'yish
words.Insert(1, "uzum");
// Element mavjudligini tekshirish
bool containsAnor = words.Contains("anor");
Console.WriteLine($"So'zlar ro'yxati: {string.Join(", ", words)}");
Console.WriteLine($"'anor' so'zi mavjudmi? {containsAnor}");

// Misol 5.
Console.WriteLine("-------- Misol 5 --------");
Console.WriteLine("O'zbekcha-Inglizcha lug'at:");
Dictionary<string, string> uzEnDict = new Dictionary<string, string>
{
    { "salom", "hello" },
    { "kitob", "book" },
    { "dunyo", "world" }
};

foreach (var pair in uzEnDict)
{
    Console.WriteLine($"{pair.Key} - {pair.Value}");
}

// Misol 6.
Console.WriteLine("-------- Misol 6 --------");
int[] b = { 24, 5, 16, 9, 37, 28, 4, 32 };
Queue<int> queue = new Queue<int>(b);
Stack<int> stack = new Stack<int>(b);
HashSet<int> hashSet = new HashSet<int>(b);
Console.WriteLine($"Queue: {string.Join(", ", queue)}");
Console.WriteLine($"Stack: {string.Join(", ", stack)}");
Console.WriteLine($"HashSet: {string.Join(", ", hashSet)}");
