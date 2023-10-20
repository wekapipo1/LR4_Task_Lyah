using System;

class Par
{
    protected double a;
    protected double b;
    protected double alpha;
    public Par(double a, double b, double alpha) //конструктор
    {
        this.a = a;
        this.b = b;
        this.alpha = alpha * Math.PI / 180; // переведення кута з градусів в радіани
    }
    public void Print()  //виведення на екран
    {
        Console.WriteLine($"Сторона a: {a}");
        Console.WriteLine($"Сторона b: {b}");
        Console.WriteLine($"Кут alpha: {alpha * 180 / Math.PI:F1} градусiв");
    }
    virtual public double Sqr() //віртуальний метод (площа)
    {
        return a * b * Math.Sin(alpha);
    }
    public double Diag(out double secondDiagonal) //обчислення діагоналей
    {
        double d1 = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(alpha));
        secondDiagonal = d1;
        return d1;
    }
}
class Pryam : Par
{
    public Pryam(double a, double b) : base(a, b, 90) //конструктор
    {
    }
    public override double Sqr() //перевизначений метод обчислення площі
    {
        return a * b;
    }
    public double Radius() //радіус описаного кола
    {
        return Math.Sqrt(a * a + b * b) / 2;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Par figure = null; 
        Random rand = new Random();
        for (int i = 0; i < 3; i++)
        {
            int choice = rand.Next(2);
            double a = rand.Next(1, 10);
            double b = rand.Next(1, 10);
            string figureType = "";

            if (choice == 0)
            {
                double angle = rand.Next(1, 180);
                figure = new Par(a, b, angle); //змінна батьківського класу
                figureType = "Паралелограм";
            }
            else
            {
                figure = new Pryam(a, b); //змінна дочірнього класу
                figureType = "Прямокутник";
            }

            Console.WriteLine($"Фiгура {i + 1} ({figureType}):");
            figure.Print();
            Console.WriteLine($"Площа: {figure.Sqr():F2}");

            if (figure is Pryam)
            {
                Pryam rectangle = (Pryam)figure;
                Console.WriteLine($"Радiус описаного кола: {rectangle.Radius():F2}");
            }

            double diagonal;
            double secondDiagonal = 0;
            diagonal = figure.Diag(out secondDiagonal);
            Console.WriteLine($"Дiагональ: {diagonal:F2}");
            if (secondDiagonal != 0)
            {
                Console.WriteLine($"Друга дiагональ: {secondDiagonal:F2}");
            }
            Console.WriteLine();
        }
    }
}
