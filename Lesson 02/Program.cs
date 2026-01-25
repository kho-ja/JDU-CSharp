// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int a = 5;
int b = 10;

int sum = a + b;
Console.WriteLine($"The sum of {a} and {b} is {sum}.");

int product = a * b;
Console.WriteLine($"The product of {a} and {b} is {product}.");

int difference = b - a;
Console.WriteLine($"The difference when {a} is subtracted from {b} is {difference}.");

int quotient = b / a;
Console.WriteLine($"The quotient when {b} is divided by {a} is {quotient}.");

// Cube side length
int sideLength = 3;

int volume = sideLength * sideLength * sideLength;
Console.WriteLine($"The volume of a cube with side length {sideLength} is {volume}.");

int area = 6 * (sideLength * sideLength);
Console.WriteLine($"The surface area of a cube with side length {sideLength} is {area}.");

// Calculate right triangle hypotenuse
double baseLength = 4.0;
double heightLength = 3.0;
double hypotenuse = Math.Sqrt((baseLength * baseLength) + (heightLength * heightLength));
Console.WriteLine($"The hypotenuse of a right triangle with base {baseLength} and height {heightLength} is {hypotenuse}.");

double perimeter = baseLength + heightLength + hypotenuse;
Console.WriteLine($"The perimeter of the triangle is {perimeter}.");

double areaTriangle = 0.5 * baseLength * heightLength;
Console.WriteLine($"The area of the triangle is {areaTriangle}.");

// tax calculation
double price = 100.0;
double taxRate = 0.12; // 7% tax
double anotherTax = 0.01; // 5% tax
double totalTax = price * taxRate + price * anotherTax;
Console.WriteLine($"The total tax on an item priced at {price} with rates of {taxRate * 100}% and {anotherTax * 100}% is {totalTax}.");

// Calculate brick wall area
double bircksPerMeterSquare = 12;
double wallLength = 10.0; // in meters
double wallHeight = 2.5; // in meters
double wallArea = wallLength * wallHeight;
Console.WriteLine($"The area of the wall is {wallArea} square meters.");

double numberOfBricks = wallArea * bircksPerMeterSquare;
Console.WriteLine($"The number of bricks needed for the wall is {numberOfBricks}.");