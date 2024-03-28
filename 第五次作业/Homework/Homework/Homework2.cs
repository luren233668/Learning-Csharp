namespace Homework;

public class Homework2
{
    // 使用Random类生成随机数
    private Random _random = new Random();
    // 存储随机整数
    private List<int> _list = new List<int>();

    public Homework2()
    {
        // 填充随机整数
        for (var i = 0; i < 100; i++)
        {
            _list.Add(_random.Next(0, 1001));
        }
    }

    // 求出结果并打印
    public void FindAndWrite()
    {
        // 使用LINQ的查询方法语法对_list进行排序
        var sortList = _list.OrderDescending();
        // 求出和
        var sum = sortList.Sum();
        // 求出平均值
        var average = sortList.Average();
        
        // 打印结果
        Console.WriteLine("排序后的整数：");
        foreach (var number in sortList)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine($"\n整数的总和：{sum}");
        Console.WriteLine($"整数的平均值：{average}");
    }
}