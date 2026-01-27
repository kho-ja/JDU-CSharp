public class Racing
{
    private readonly List<RacingCar> _cars;
    private readonly double _distanceKm;
    private readonly int _failedIndex;
    private readonly object _consoleLock = new();

    public Racing(double distanceKm, List<RacingCar> cars, int failedIndex)
    {
        _distanceKm = distanceKm;
        _cars = cars;
        _failedIndex = failedIndex;
    }

    public void Start()
    {
        Console.WriteLine($"Masofa: {_distanceKm:0.00} km");
        Console.WriteLine("Poyga boshlandi!");

        var threads = new List<Thread>();
        for (var i = 0; i < _cars.Count; i++)
        {
            var index = i;
            var thread = new Thread(() => RunCar(_cars[index], index == _failedIndex));
            threads.Add(thread);
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("Poyga yakunlandi.");
        foreach (var car in _cars)
        {
            if (car.Finished)
            {
                Console.WriteLine($"{car.Name} - {car.FinishTimeSeconds} sekundda yetib keldi.");
            }
            else
            {
                Console.WriteLine($"{car.Name} - texnik nosozlik, marraga yetmadi.");
            }
        }
    }

    private void RunCar(RacingCar car, bool hasFailure)
    {
        var distance = 0.0;
        var seconds = 0;
        var speedPerSecond = car.SpeedKmh / 3600.0;

        while (distance < _distanceKm)
        {
            Thread.Sleep(1000);
            seconds++;
            distance += speedPerSecond;

            if (hasFailure && distance >= _distanceKm / 2)
            {
                lock (_consoleLock)
                {
                    Console.WriteLine($"{car.Name} 1/2 masofada nosozlikka uchradi.");
                }

                car.Finished = false;
                return;
            }

            lock (_consoleLock)
            {
                Console.WriteLine($"{car.Name}: {seconds}s -> {distance:0.00} km");
            }
        }

        car.Finished = true;
        car.FinishTimeSeconds = seconds;
    }
}

public class RacingCar
{
    public string Name { get; }
    public double SpeedKmh { get; }
    public bool Finished { get; set; }
    public int FinishTimeSeconds { get; set; }

    public RacingCar(string name, double speedKmh)
    {
        Name = name;
        SpeedKmh = speedKmh;
    }
}
