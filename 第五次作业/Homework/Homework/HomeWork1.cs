using System.Collections;

namespace Homework;

public class HomeWork1
{
    // 使用BitArray来存储一个数是否为质数的标记，true表示是质数，false表示不是
    private BitArray _isPrime;
    // 定义搜索的最小值和最大值
    private readonly int _max;
    private readonly int _min;

    public HomeWork1(int min, int max)
    {
        // 初始化实例变量
        _isPrime = new BitArray(max + 1, true);
        _min = min;
        _max = max;
    }

    // 筛法标记质数和非质数
    private void GetPrime()
    {
        for (var i = 2; i * i <= _max; i++)
        {
            // 如果当前数已经被标记为非质数，则跳过
            if (!_isPrime[i])
            {
                continue;
            }
            // 从i的平方开始，标记所有i的倍数为非质数
            for (var j = i * i; j <= _max; j += i)
            {
                _isPrime[j] = false;
            }
        }
    }

    // 调用GetPrime方法后打印所有满足条件的偶数及其质数之和的表示
    public void Write()
    {
        // 首先标记所有非质数
        GetPrime();
        // 遍历指定范围内的所有偶数
        for (var i = _min; i <= _max; i += 2)
        {
            // 对于每个偶数i，遍历所有小于等于i/2的数
            for (var j = 3; j < ((i / 2) + 1); j++)
            {
                // 如果j和i-j都是质数，则输出
                if (_isPrime[j] && _isPrime[i - j])
                {
                    Console.Write($"{i} = {j} + {i - j}  \t");
                }
            }
            Console.WriteLine();
        }
    }
}