// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// find maximum of two numbers
int x = 15;
int y = 25;

if (x > y)
{
    Console.WriteLine($"The maximum of {x} and {y} is {x}.");
}
else
{
    Console.WriteLine($"The maximum of {x} and {y} is {y}.");
}


// square equation solver
double a = 1.0;
double b = -3.0;
double c = 2.0;

double discriminant = b * b - 4 * a * c;
if (discriminant > 0)
{
    double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
    double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
    Console.WriteLine($"The roots of the equation are {root1} and {root2}.");
}
else if (discriminant == 0)
{
    double root = -b / (2 * a);
    Console.WriteLine($"The equation has one root: {root}.");
}
else
{
    Console.WriteLine("The equation has no real roots.");
}


// Ob-Havoni aytadigan dastur

double temperatureCelsius = 25.0;

switch (temperatureCelsius)
{
    case < -10:
        Console.WriteLine("anomal sovuq!");
        break;
    case < 0:
        Console.WriteLine("sovuq!");
        break;
    case < 15:
        Console.WriteLine("iliq!");
        break;
    case < 30:
        Console.WriteLine("issiq!");
        break;
    case < 42:
        Console.WriteLine("juda issiq!");
        break;
    default:
        Console.WriteLine("anomal issiq!");
        break;
}

// Calculator with switch expression
double num1 = 8.0;
double num2 = 4.0;
string operation = "divide";

double result = operation switch
{
    "add" => num1 + num2,
    "subtract" => num1 - num2,
    "multiply" => num1 * num2,
    "divide" => num1 / num2,
    _ => throw new InvalidOperationException("Unknown operation")
};
Console.WriteLine($"The result of {operation}ing {num1} and {num2} is {result}.");

// Calculate array with Natural Numbers
int[] naturalNumbers = new int[10];
for (int i = 0; i < naturalNumbers.Length; i++)
{
    naturalNumbers[i] = i + 1;
}

Console.WriteLine("Natural Numbers:");
foreach (int number in naturalNumbers)
{
    Console.WriteLine(number);
}

double sumNaturalNumbers = 0;
foreach (int number in naturalNumbers)
{
    sumNaturalNumbers += number;
}
Console.WriteLine($"The sum of the first {naturalNumbers.Length} natural numbers is {sumNaturalNumbers}.");

// Multiplication table
Console.WriteLine("Multiplication Table:");

for (int t = 0; t < 2; t++)
{
    for (int i = 0; i < 10; i++)
    {
        for (int j = 0; j < 5; j++)
        {
            Console.Write($"{j + 1} x {i + 1} = {(i + 1) * (j + 1)}".PadRight(15) + "| ");
        }
        Console.WriteLine();
    }
    Console.WriteLine("".PadRight(85, '-'));
}