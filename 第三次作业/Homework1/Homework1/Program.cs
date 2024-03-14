namespace Homework1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var shapes = new List<IFigure>();

            // 随机创建10个形状对象
            for (var i = 0; i < 10; i++)
            {
                shapes.Add(ShapeFactory.CreateRandomShape());
            }
            
            //可以使用Shape的静态方法检查类型
            if (Shape.IsInstanceOf<Circle>(shapes[1]))
            {
                Console.WriteLine(shapes[1] + " Radius: " + ((Circle)shapes[1]).Radius);
            }
            else if (Shape.IsInstanceOf<Rectangle>(shapes[1]))
            {
                Console.WriteLine(shapes[1] + " Width: " + ((Rectangle)shapes[1]).Width + " Height: " + ((Rectangle)shapes[1]).Height);
            }
            else if (Shape.IsInstanceOf<Square>(shapes[1]))
            {
                Console.WriteLine(shapes[1] + " SideLength: " + ((Square)shapes[1]).SideLength);
            }
            else
            {
                Console.WriteLine("不合法的形状!");
            }

            // 计算所有形状的面积之和
            double totalArea = 0;
            foreach (var shape in shapes)
            {
                if (shape.IsLegal())
                {
                    shape.PrintDetails();
                    totalArea += shape.Area();
                }
                else
                {
                    Console.WriteLine("存在不合法的形状!");
                }
            }

            Console.WriteLine($"所有形状的面积之和为: {totalArea}");
        }
    }
}