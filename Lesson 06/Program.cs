// C# fanidan 6-amaliy topshiriq.
// Mavzu: Nomlar fazosida tiplarni yaratish
// Ishning maqsadi: Talabalarda C# dasturlash tilida nomlar fazosining o’rni va
// ahamiyati hamda ularning tarkibida tiplarni (struct, enum, class) yaratish
// yondashuvlarini o’rgatishdan iborat.
// Bajariladigan vazifalar:
// 1. Loyiha yarating va unda uchta nomlar fazosini yarating. Har bir nomlar
// fazosida yangi tiplarni yarating. Nomlar fazosining nima uchun
// yaratilishini va unda qanday tiplar yaratish mumkinligini tushuntirib bering.
// 2. Har bir talaba struktura (struct) uchun bir-biriga o’xshamagan misol
// (masalan: computers, notebooks, phones, students, workers,
// universities, games, books va h.k.) o’ylab, yangi tipni yaratishi talab
// etiladi. Tip tarkibida qiymat kiritish va chiqarish metodlari bo’lishi
// kerak. Dasturning asosiy metodi (Main)da yaratilgan tipdan
// obyekt-o‘zgaruvchi yarating va undan foydalaning.
// 3. Ro’yxat (enum) tipini yaratish uchun quyidagi misollardan
// foydalaning: MyWorkingDay, Season, TrafficLight, Month. Yaratilgan
// ro‘yxat tipidan dasturingizda foydalaning.
// 4. 2-vazifada tanlagan struktura (struct) tipining bir maydoni uchun
// ro’yxat (enum) tipini bering. Struktura obyekti orqali shu ro’yxat
// elementi qiymatlarini kiritish va chiqarish metodlarini yarating.
// Natijalarni ekranga chiqaring.
// 5. Struktura (struct) va sinf (class) tiplarining farqini tushuntirib bering.

Console.WriteLine("Lesson 06 - Namespaces and Types");
Console.WriteLine("-------- Misol 1 ---------");
Console.WriteLine("Nomlar fazosi (namespace) bir xil nomdagi tiplardan keladigan to’qnashuvlarni");
Console.WriteLine("oldini oladi va loyihani mantiqiy bo’limlarga ajratishga yordam beradi.");
Console.WriteLine("Namespace ichida struct, enum, class kabi turlarni yaratish mumkin.");
Console.WriteLine();

Console.WriteLine("-------- Misol 2 (Enum) ---------");
var workingDay = JDU.Enums.MyWorkingDay.Monday;
var season = JDU.Enums.Season.Winter;
var traffic = JDU.Transport.TrafficLight.Green;
var month = JDU.Enums.Month.January;
Console.WriteLine($"MyWorkingDay: {workingDay}");
Console.WriteLine($"Season: {season}");
Console.WriteLine($"TrafficLight: {traffic}");
Console.WriteLine($"Month: {month}");
Console.WriteLine();

Console.WriteLine("-------- Misol 3 (Struct) ---------");
var student = new JDU.Education.Student();
student.ReadFromConsole();
student.Print();
Console.WriteLine();

Console.WriteLine("-------- Misol 4 (Class) ---------");
var teacher = new JDU.Education.Teacher("Dilshod Karimov", "Matematika");
teacher.Print();
Console.WriteLine();

var controller = new JDU.Transport.TrafficController("Markaziy ko’cha", JDU.Transport.TrafficLight.Red);
controller.Print();
Console.WriteLine();

Console.WriteLine("-------- Misol 5 (Struct vs Class) ---------");
Console.WriteLine("Struct — qiymat tipi (value type), odatda stack’da saqlanadi va kichik obyektlar");
Console.WriteLine("uchun samarali. Class — havola tipi (reference type), heap’da saqlanadi,");
Console.WriteLine("meros olish va polimorfizm kabi imkoniyatlarga ega.");

namespace JDU.Enums
{
    public enum MyWorkingDay
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    public enum Season
    {
        Winter,
        Spring,
        Summer,
        Autumn
    }

    public enum Month
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
}

namespace JDU.Transport
{
    public enum TrafficLight
    {
        Red,
        Yellow,
        Green
    }

    public class TrafficController
    {
        public string Location { get; }
        public TrafficLight State { get; private set; }

        public TrafficController(string location, TrafficLight state)
        {
            Location = location;
            State = state;
        }

        public void Print()
        {
            Console.WriteLine($"Joylashuv: {Location}");
            Console.WriteLine($"Svetofor holati: {State}");
        }
    }
}

namespace JDU.Education
{
    public struct Student
    {
        public string FullName;
        public int Age;
        public JDU.Enums.Month EnrollmentMonth;

        public void ReadFromConsole()
        {
            Console.Write("Ism va familiya kiriting: ");
            FullName = Console.ReadLine() ?? string.Empty;

            Age = ReadInt("Yosh kiriting: ", 1, 120);
            EnrollmentMonth = ReadEnum<JDU.Enums.Month>("Qabul oyi (Month) kiriting: ");
        }

        public void Print()
        {
            Console.WriteLine($"Ism: {FullName}");
            Console.WriteLine($"Yosh: {Age}");
            Console.WriteLine($"Qabul oyi: {EnrollmentMonth}");
        }

        private static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();
                if (int.TryParse(input, out var value) && value >= min && value <= max)
                {
                    return value;
                }

                Console.WriteLine($"Iltimos, {min} va {max} oralig’ida son kiriting.");
            }
        }

        private static TEnum ReadEnum<TEnum>(string prompt) where TEnum : struct, Enum
        {
            while (true)
            {
                Console.WriteLine($"Mavjud variantlar: {string.Join(", ", Enum.GetNames(typeof(TEnum)))}");
                Console.Write(prompt);
                var input = Console.ReadLine();
                if (Enum.TryParse<TEnum>(input, true, out var result))
                {
                    return result;
                }

                Console.WriteLine("Noto’g’ri qiymat. Qayta urinib ko’ring.");
            }
        }
    }

    public class Teacher
    {
        public string FullName { get; }
        public string Subject { get; }

        public Teacher(string fullName, string subject)
        {
            FullName = fullName;
            Subject = subject;
        }

        public void Print()
        {
            Console.WriteLine($"O’qituvchi: {FullName}");
            Console.WriteLine($"Fan: {Subject}");
        }
    }
}
