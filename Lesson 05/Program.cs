// C# fanidan 5-amaliy topshiriq.
// Mavzu: Usullar va funksiyalar. Statik usullar
// Ishning maqsadi: Talabalarda C# dasturlash tilida funksiyalar va statik usullarni
// yaratish hamda ulardan foydalanish ko’nikmalarni hosil qilishdan iborat.
// Bajariladigan vazifalar:
// 1. O’zgaruvchiga qiymatni kirituvchi va shu o’zgaruvchining qiymatini
// chiqaruvchi usullarni yarating. Usullarni sinf obyekti yordamida chaqiring.
// 2. Talabalar IDlari yozilgan lug’at (Dictionary) berilgan (masalan 10 tacha).
// Ular orasidan tasodifiy 3 tasini tanlab, ma’lumotlarini konsol oynasiga
// chiqaruvchi usulni yarating va sinf obyekti yordamida chaqirib, ishga
// tushiring.
// 3. Standart sinflarning statik usullaridan foydalanmasdan ularni mustaqil
// ravishda yarating: MyMax, MyMin, MyPow, MyBubbleSort. Yaratgan
// statik usulingizni sinf nomi orqali chaqirib foydalaning.
// 4. Daromatingiz (D) har oyda 1 / 50 ulushga oshib borganda oylik va yillik
// daromadni hisoblash uchun funksiyalar yarating
// 5. Sonning 0 dan n1 gacha qismining 8 foizini, n1+1 dan n2 gacha
// qismidan 12 foizini, undan yuqori qismidan 18 foizini hisoblash va
// ularning, summasini ekranga chiqaruvchi funksiya yarating. Natija
// oynasiga son, har bir qismning foizlari, foizlar summasi chiqarilsin.

// Misol 1:
Console.WriteLine("-------- Misol 1 --------");

MyProgram obj = new MyProgram();
obj.SetNumber();
obj.DisplayNumber();


// Misol 2:
Console.WriteLine("-------- Misol 2 --------");
// Dictionary yaratish va ma'lumotlarni qo'shish
Dictionary<int, string> studentIDs = new Dictionary<int, string>()
{
    { 101, "Ali" },
    { 102, "Vali" },
    { 103, "Guli" },
    { 104, "Sami" },
    { 105, "Nuri" },
    { 106, "Lola" },
    { 107, "Dina" },
    { 108, "Olim" },
    { 109, "Zara" },
    { 110, "Rashid" }
};
// Tasodifiy 3 ta ID tanlash va chiqarish
Random rand = new Random();
List<int> keys = new List<int>(studentIDs.Keys);
HashSet<int> selectedKeys = new HashSet<int>();
foreach (int key in keys)
{
    if (selectedKeys.Count >= 3)
        break;
    int randomIndex = rand.Next(keys.Count);
    selectedKeys.Add(keys[randomIndex]);
}
Console.WriteLine("Tasodifiy tanlangan talabalar:");
foreach (int key in selectedKeys)
{
    Console.WriteLine($"ID: {key}, Ism: {studentIDs[key]}");
}


// Misol 3:
Console.WriteLine("-------- Misol 3 --------");
int max = MyMath.MyMax(10, 20);
Console.WriteLine("Max: " + max);
int min = MyMath.MyMin(10, 20);
Console.WriteLine("Min: " + min);
double power = MyMath.MyPow(2, 3);
Console.WriteLine("Power: " + power);
int[] arr = { 5, 2, 9, 1, 5, 6 };
MyMath.MyBubbleSort(arr);
Console.WriteLine("Sorted Array: " + string.Join(", ", arr));

// Misol 4:
Console.WriteLine("-------- Misol 4 --------");
Func<int, int> CalculateMonthlyIncome = (D) =>
{
    return D + (D / 50);
};
int initialIncome = 1000; // boshlang'ich daromad
for (int month = 1; month <= 12; month++)
{
    initialIncome = CalculateMonthlyIncome(initialIncome);
    Console.WriteLine($"Month {month}: {initialIncome}");
}

Func<int, int> CalculateYearlyIncome = (D) =>
{
    for (int month = 1; month <= 12; month++)
    {
        D = CalculateMonthlyIncome(D);
    }
    return D;
};
int yearlyIncome = CalculateYearlyIncome(1000);
Console.WriteLine("Yillik daromad: " + yearlyIncome);

// Misol 5:
Console.WriteLine("-------- Misol 5 --------");
Func<double, double> CalculateTax = (n) =>
{
    double tax = 0;
    if (n <= 1000)
    {
        tax = n * 0.08;
    }
    else if (n <= 5000)
    {
        tax = (1000 * 0.08) + ((n - 1000) * 0.12);
    }
    else
    {
        tax = (1000 * 0.08) + (4000 * 0.12) + ((n - 5000) * 0.18);
    }
    return tax;
};
double income = 6000; // misol uchun daromad
double totalTax = CalculateTax(income);
Console.WriteLine("Umumiy Soliq: " + totalTax);

public static class MyMath
{
    public static int MyMax(int a, int b)
    {
        return (a > b) ? a : b;
    }

    public static int MyMin(int a, int b)
    {
        return (a < b) ? a : b;
    }

    public static double MyPow(double baseNum, double exponent)
    {
        double result = 1;
        for (int i = 0; i < exponent; i++)
        {
            result *= baseNum;
        }
        return result;
    }

    public static void MyBubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap arr[j] and arr[j+1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
}

class MyProgram
{
    int number;

    public void SetNumber()
    {
        Console.Write("Son Kiriting: ");
        int num = int.Parse(Console.ReadLine() ?? "0");
        number = num;
    }

    public void DisplayNumber()
    {
        Console.WriteLine("Kiritilgan son: " + number);
    }
}
