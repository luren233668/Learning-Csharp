namespace Homework1;

//圆形类
public class Circle : IFigure
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }
    
    public double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public bool IsLegal()
    {
        return Radius > 0;
    }
    
    public void PrintDetails()
    {
        Console.WriteLine($"Circle: Radius = {Radius}");
    }
}