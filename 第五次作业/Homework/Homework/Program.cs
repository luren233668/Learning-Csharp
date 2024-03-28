// See https://aka.ms/new-console-template for more information

namespace Homework;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("作业1：");
        var hioHomeWork1 = new HomeWork1(6, 100);
        hioHomeWork1.Write();
        
        Console.WriteLine("作业2");
        var homework2 = new Homework2();
        homework2.FindAndWrite();
    }
}