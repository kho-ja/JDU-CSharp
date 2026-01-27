// C# fanidan 12-amaliy topshiriq.
// Mavzu: Matnlar bilan ishlash
// Ishning maqsadi: Talabalarga String sinfining imkoniyatlari va
// afzalliklaridan foydalangan holda matnlar bilan ishlash bilim va
// ko'nikmalarini hosil qilishdan iborat.
// Bajariladigan vazifalar:
// 1. Dasturda kodida 20 ta so'zdan kam bo'lmagan matn kiritilgan
// bo'lsin. Matnda takrorlangan so'zlarni aniqlab beruvchi dastur
// tuzilsin. Matndagi darak gap va so'roq gaplarning soni
// aniqlansin.
// 2. Parolni turli simvollar bilan generatsiya qilib chiqarish dasturi
// tuzilsin.
// 3. Matndan palindrom so'zlarni topish dasturi tuzilsin.

Console.WriteLine("Lesson 12 - Working with Text");
Console.WriteLine("-------- 1. Matn tahlili --------");

string text =
    "Bugun universitetda talabalar dasturlash asoslari haqida gaplashdi. " +
    "Ular yangi mavzularni tez o'zlashtirdi va amaliy mashqlarni bajarishdi. " +
    "Siz bugun kutubxonaga borasizmi? " +
    "Biz kecha bir xil so'zlarni topish vazifasini ko'rdik va natijani yozdik. " +
    "Matn bilan ishlash qiziqarli, matn bilan ishlash foydali.";

Console.WriteLine(text);
Console.WriteLine();

var words = Tokenize(text);
var repeated = words
    .GroupBy(w => w)
    .Where(g => g.Count() > 1)
    .OrderBy(g => g.Key)
    .ToList();

Console.WriteLine("Takrorlangan so'zlar:");
if (repeated.Count == 0)
{
    Console.WriteLine("Topilmadi.");
}
else
{
    foreach (var group in repeated)
    {
        Console.WriteLine($"{group.Key} -> {group.Count()} marta");
    }
}

var declarativeCount = text.Count(ch => ch == '.');
var questionCount = text.Count(ch => ch == '?');
Console.WriteLine();
Console.WriteLine($"Darak gaplar soni: {declarativeCount}");
Console.WriteLine($"So'roq gaplar soni: {questionCount}");

Console.WriteLine();
Console.WriteLine("-------- 2. Parol generatsiyasi --------");
var password = GeneratePassword(12);
Console.WriteLine($"Yangi parol: {password}");

Console.WriteLine();
Console.WriteLine("-------- 3. Palindrom so'zlar --------");
var palindromes = words
    .Where(w => w.Length > 1 && IsPalindrome(w))
    .Distinct()
    .OrderBy(w => w)
    .ToList();

if (palindromes.Count == 0)
{
    Console.WriteLine("Palindrom so'zlar topilmadi.");
}
else
{
    Console.WriteLine(string.Join(", ", palindromes));
}

static List<string> Tokenize(string input)
{
    var result = new List<string>();
    var current = new List<char>();

    foreach (var ch in input)
    {
        if (char.IsLetterOrDigit(ch))
        {
            current.Add(char.ToLowerInvariant(ch));
        }
        else if (current.Count > 0)
        {
            result.Add(new string(current.ToArray()));
            current.Clear();
        }
    }

    if (current.Count > 0)
    {
        result.Add(new string(current.ToArray()));
    }

    return result;
}

static bool IsPalindrome(string word)
{
    var left = 0;
    var right = word.Length - 1;

    while (left < right)
    {
        if (word[left] != word[right])
        {
            return false;
        }

        left++;
        right--;
    }

    return true;
}

static string GeneratePassword(int length)
{
    if (length < 4)
    {
        length = 4;
    }

    const string lower = "abcdefghijklmnopqrstuvwxyz";
    const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const string digits = "0123456789";
    const string symbols = "!@#$%&*_-+=";

    var random = new Random();
    var chars = new List<char>
    {
        lower[random.Next(lower.Length)],
        upper[random.Next(upper.Length)],
        digits[random.Next(digits.Length)],
        symbols[random.Next(symbols.Length)]
    };

    var all = lower + upper + digits + symbols;
    while (chars.Count < length)
    {
        chars.Add(all[random.Next(all.Length)]);
    }

    // Shuffle
    for (var i = chars.Count - 1; i > 0; i--)
    {
        var j = random.Next(i + 1);
        (chars[i], chars[j]) = (chars[j], chars[i]);
    }

    return new string(chars.ToArray());
}
