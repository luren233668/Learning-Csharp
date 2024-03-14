namespace Homework1;

//正方形类
public class Square : IFigure
{
    public double SideLength { set; get; }

    public Square(double sideLength)
    {
        SideLength = sideLength;
    }

    public double Area()
    {
        return SideLength * SideLength;
    }

    public bool IsLegal()
    {
        return SideLength > 0;
    }
    
    public void PrintDetails()
    {
        Console.WriteLine($"Square: SideLength = {SideLength}");
    }
}