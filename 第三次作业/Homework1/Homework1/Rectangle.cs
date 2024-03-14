namespace Homework1;

// 长方形类
public class Rectangle : IFigure
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double Area()
    {
        return Width * Height;
    }

    public bool IsLegal()
    {
        return Width > 0 && Height > 0;
    }
    
    public void PrintDetails()
    {
        Console.WriteLine($"Rectangle: Width = {Width}, Height = {Height}");
    }
}