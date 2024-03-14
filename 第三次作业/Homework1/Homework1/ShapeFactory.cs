namespace Homework1;

//形状工厂类
public class ShapeFactory
{
    // 随机创建一个形状对象
    private static  Random _random= new Random();
    
    // 随机创建一个形状对象
    public static IFigure CreateRandomShape()
    {
        var shapeType = _random.Next(1, 4);

        return shapeType switch
        {
            1 => new Rectangle(_random.NextDouble() * 10, _random.NextDouble() * 10),
            2 => new Square(_random.NextDouble() * 10),
            3 => new Circle(_random.NextDouble() * 10),
            _ => throw new ArgumentException("Invalid shape type")
        };
    }
}