using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GenericSample<Type>
{
    Type _item;

    public GenericSample(Type value)
    {
        _item = value;
    }
}

public class TwoGeneric<K, V>
{
    K key;
    V value;

    public TwoGeneric(K key, V value)
    {
        this.key = key;
        this.value = value;
    }
}

public static class GenericUtils
{
    public static T Max<T>(T arg1, T arg2) where T : IComparable
    {
        if (arg1.CompareTo(arg2) >= 0)
        {
            return arg1;
        }

        return arg2;
    }
}

public class GenericPrac
{

}
