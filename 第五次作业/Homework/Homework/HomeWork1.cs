using System.Collections;

namespace Homework;

public class HomeWork1
{
    private BitArray _isPrime;
    private int _max;
    private int _min;

    public HomeWork1(int min, int max)
    {
        _isPrime = new BitArray(max + 1, true);
        _min = min;
        _max = max;
    }

    private void GetPrime()
    {
        for (var i = 2; i * i <= _max; i++)
        {
            if (!_isPrime[i])
            {
                continue;
            }
            
            for (var j = i * i; j <= _max; j += i)
            {
                _isPrime[j] = false;
            }
        }
    }

    public void Write()
    {
        GetPrime();
        for (var i = _min; i <= _max; i += 2)
        {
            for (var j = 3; j < ((i / 2) + 1); j++)
            {
                if (_isPrime[j] && _isPrime[i - j])
                {
                    Console.Write($"{i} = {j} + {i - j}  \t");
                }
            }
            Console.WriteLine();
        }
    }
}