namespace Homework1;

public class Shape
{
    // 静态方法：判断对象是否为指定类型的实例，并检查形状是否合法
    public static bool IsInstanceOf<T>(object o) where T : IFigure
    {
        return o is T shape && shape.IsLegal();
    }
}