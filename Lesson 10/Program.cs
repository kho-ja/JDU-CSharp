// C# fanidan 10-amaliy topshiriq.
// Mavzu: Inkapsulyatsiya va abstraksiya
// Ishning maqsadi: Talabalarga inkapsulyatsiya va abstraksiya
// tamoyillariga asoslanib sinflar yaratish bilim va ko'nikmalarini
// o'rgatishdan iborat.
// Bajariladigan vazifalar:
// 1. Tanlangan masala (class) bo'yicha inkapsulyatsiyani joriy qiling
// va (private, protected, public) modifikatorlardan to'g'ri foylaning.
// 2. Tanlangan masala (class) bo'yicha abstrakt yoki interfeys
// yaratish mumkinligini mantiqan tahlil qiling hamda sinf uchun
// abstrakt sinf yoki interfeys yarating. Abstrakt metodlardan
// foydalaning.

Console.WriteLine("Lesson 10 - Encapsulation and Abstraction");
Console.WriteLine("-------- 1. Inkapsulyatsiya --------");
Console.WriteLine("private - ichki holatni yashiradi, protected - voris sinflar ko'radi,");
Console.WriteLine("public - tashqi kodga ochiq a'zolar.");
Console.WriteLine();

var savings = new SavingsAccount("ACC-001", "Ali", 0.02m);
savings.Deposit(5000m);
savings.Withdraw(1200m);
savings.PrintSummary();
Console.WriteLine($"Oylik xizmat haqi: {savings.CalculateMonthlyFee()}");
Console.WriteLine();

var premium = new PremiumAccount("ACC-002", "Sami", 0.01m, 15m);
premium.Deposit(12000m);
premium.PrintSummary();
Console.WriteLine($"Oylik xizmat haqi: {premium.CalculateMonthlyFee()}");
Console.WriteLine();

Console.WriteLine("-------- 2. Abstraksiya --------");
Console.WriteLine("AccountBase abstrakt sinf bo'lib, umumiy xususiyatlarni beradi va");
Console.WriteLine("CalculateMonthlyFee hamda PrintSummary metodlarini majburiy qiladi.");

public abstract class AccountBase
{
    protected string AccountNumber { get; }
    public string Owner { get; }

    protected AccountBase(string accountNumber, string owner)
    {
        AccountNumber = accountNumber;
        Owner = owner;
    }

    public abstract decimal CalculateMonthlyFee();
    public abstract void PrintSummary();
}

public class SavingsAccount : AccountBase
{
    private decimal _balance;

    public decimal Balance => _balance;
    public decimal InterestRate { get; private set; }

    public SavingsAccount(string accountNumber, string owner, decimal interestRate)
        : base(accountNumber, owner)
    {
        SetInterestRate(interestRate);
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            return;
        }

        _balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0 || amount > _balance)
        {
            return false;
        }

        _balance -= amount;
        return true;
    }

    public override decimal CalculateMonthlyFee()
    {
        return 0m;
    }

    public override void PrintSummary()
    {
        Console.WriteLine($"Hisob raqami: {AccountNumber}");
        Console.WriteLine($"Egasi: {Owner}");
        Console.WriteLine($"Balans: {Balance}");
        Console.WriteLine($"Foiz stavkasi: {InterestRate}");
    }

    private void SetInterestRate(decimal rate)
    {
        InterestRate = rate < 0 ? 0 : rate;
    }
}

public class PremiumAccount : AccountBase
{
    private decimal _balance;
    private readonly decimal _monthlyFee;

    public decimal Balance => _balance;

    public PremiumAccount(string accountNumber, string owner, decimal interestRate, decimal monthlyFee)
        : base(accountNumber, owner)
    {
        InterestRate = interestRate < 0 ? 0 : interestRate;
        _monthlyFee = monthlyFee < 0 ? 0 : monthlyFee;
    }

    public decimal InterestRate { get; }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            return;
        }

        _balance += amount;
    }

    public override decimal CalculateMonthlyFee()
    {
        return _monthlyFee;
    }

    public override void PrintSummary()
    {
        Console.WriteLine($"Hisob raqami: {AccountNumber}");
        Console.WriteLine($"Egasi: {Owner}");
        Console.WriteLine($"Balans: {Balance}");
        Console.WriteLine($"Foiz stavkasi: {InterestRate}");
    }
}
