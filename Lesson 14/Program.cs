// C# fanidan 14-amaliy topshiriq.
// Mavzu: Oqimlar va ko'poqimlilik
// Ishning maqsadi: Talabalarga oqimlar bilan ishlash, ko'poqimlilik
// imkoniyatlari haqidagi bilim va ko'nikmalarini berishdan iborat.
// Bajariladigan vazifalar:
// 1. “27-28. Oqimlar va ko'poqimlilik” videosida keltirilgan lift masalasi
// uchun dastur tuzing va o'zgarishlar kiritishga harakat qilib ko'ring.
// 2. Poyga musobaqasi uchun 4 ta avtomobil mavjud va ularning
// tezliklari har xil bo'lsin. Bu obyektlar uchun alohida faylga Racing
// sinfini yarating. Ular A manzildan B manzilga tomon
// harakatlanishadi. A va B manzillar orasidagi masofa berilgan.
// Har bir poyga mashinasi bir vaqtda A nuqtadan yo'lga chiqadi.
// Ular uchun oqim obyektlari tashkil qilinishi lozim. Yarim yo'lda
// texnik nosozlik tufayli 1 ta mashina B manzilga yetolmaydi. Oqim
// orqali ularning har bir sekundda qancha masofa yurganliklarini
// aniqlab borish kerak. Mashinalar B manzilga qancha vaqtda
// yetib kelishadi.

Console.WriteLine("Lesson 14 - Threads and Multithreading");
Console.WriteLine("-------- 1. Lift masalasi --------");

var elevator = new Elevator(1);
elevator.Start();

var random = new Random();
var requestThread1 = new Thread(() =>
{
    for (var i = 0; i < 3; i++)
    {
        var floor = random.Next(1, 8);
        elevator.Call(floor, "Talaba-1");
        Thread.Sleep(700);
    }
});

var requestThread2 = new Thread(() =>
{
    for (var i = 0; i < 3; i++)
    {
        var floor = random.Next(2, 10);
        elevator.Call(floor, "Talaba-2");
        Thread.Sleep(900);
    }
});

requestThread1.Start();
requestThread2.Start();

requestThread1.Join();
requestThread2.Join();

Thread.Sleep(2000);
elevator.Stop();

Console.WriteLine();
Console.WriteLine("-------- 2. Poyga musobaqasi --------");

var cars = new List<RacingCar>
{
    new RacingCar("Car-1", 90),
    new RacingCar("Car-2", 110),
    new RacingCar("Car-3", 100),
    new RacingCar("Car-4", 95)
};

var race = new Racing(5.0, cars, failedIndex: 2);
race.Start();

Console.WriteLine();
Console.WriteLine("O'zgarish uchun misol: lift tezligini (qavat oralig'i kutish vaqtini)");
Console.WriteLine("yoki poyga masofasini o'zgartirib natijalarni solishtiring.");

public class Elevator
{
    private readonly Queue<ElevatorRequest> _requests = new();
    private readonly object _lock = new();
    private readonly object _consoleLock = new();
    private readonly AutoResetEvent _signal = new(false);
    private Thread? _worker;
    private bool _running;

    public int CurrentFloor { get; private set; }

    public Elevator(int startFloor)
    {
        CurrentFloor = startFloor;
    }

    public void Start()
    {
        _running = true;
        _worker = new Thread(Run);
        _worker.Start();
    }

    public void Stop()
    {
        _running = false;
        _signal.Set();
        _worker?.Join();
    }

    public void Call(int floor, string caller)
    {
        lock (_lock)
        {
            _requests.Enqueue(new ElevatorRequest(floor, caller));
        }

        _signal.Set();
    }

    private void Run()
    {
        while (_running)
        {
            ElevatorRequest? request = null;
            lock (_lock)
            {
                if (_requests.Count > 0)
                {
                    request = _requests.Dequeue();
                }
            }

            if (request is null)
            {
                _signal.WaitOne(500);
                continue;
            }

            MoveTo(request.Floor, request.Caller);
        }
    }

    private void MoveTo(int targetFloor, string caller)
    {
        while (CurrentFloor != targetFloor)
        {
            Thread.Sleep(500);
            CurrentFloor += targetFloor > CurrentFloor ? 1 : -1;
            lock (_consoleLock)
            {
                Console.WriteLine($"Lift {CurrentFloor}-qavatda (chaqiruvchi: {caller})");
            }
        }

        lock (_consoleLock)
        {
            Console.WriteLine($"Lift {targetFloor}-qavatga yetdi ({caller})");
        }
    }
}

public record ElevatorRequest(int Floor, string Caller);
