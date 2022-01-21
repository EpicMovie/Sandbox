using System;
using System.Collections.Generic;
using System.Linq;

static class ExtensionMethodExample
{
    public static int GetWordCount(this string text)
    {
        return text.Split(' ').Length;
    }
}

class Person88
{
    string _name;
    int _age;

    public Person88() : this(string.Empty, 0) { }

    public Person88(string name) : this(name, 0) { }

    public Person88(string name, int age)
    {
        _name = name;
        _age = age;
    }
}

public class NewFuncPrac3
{
    public void Run_NewFunc()
    {
        List<int> list = new List<int>() { 5, 4, 3, 2, 1 };

        Console.WriteLine(list.Min());

        var p99 = new { Count = 10, Title = "Andrew" };

        string text = "Hello, World";

        Console.WriteLine("Count : " + text.GetWordCount());

        TestLambda();
    }

    private void TestLambda()
    {
        Action<string> logOut = (txt) => { Console.WriteLine(DateTime.Now + " : " + txt); };

        logOut("This is my World");

        Func<double> pi = () => 3.14159266;

        Console.WriteLine(pi);

        Func<int, int, int> add = (a, b) => a + b;

        Console.WriteLine(add(10, 20));

        List<int> lists = new List<int> { 3, 1, 4, 5, 2, 6 };

        lists.ForEach((elem) => Console.Write(elem + " "));
        List<int> founded = lists.FindAll((elem) => elem % 2 == 0);
        int count = lists.Count((elem) => elem % 2 == 0);

        IEnumerable<double> doubleList = lists.Select((elem) => (double)elem);

        foreach(double var in doubleList)
        {
            Console.WriteLine(var);
        }

        Array.ForEach(doubleList.ToArray(), (elem) => Console.WriteLine(elem));

        Action<int> lambda = delegate (int elem)
        {
            Console.WriteLine(elem);
        };
    }
}

