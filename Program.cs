using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleAppTest
{
    class Person
    {
        public string? Name { get; set; }

        public int Age { get; set; }

        public string? Addr { get; set; }

        public override string ToString()
        {
            return string.Format("{0} : {1} in {2}", Name, Age, Addr);
        }
    }

    class MainLang
    {
        public string? Name { get; set; }

        public string? Lang { get; set; }
    }

    public interface Command
    {
        void Execute();
    }

    public class JumpCommand : Command
    {
        public void Execute()
        {
            Jump();
        }

        private void Jump()
        {
            // Jump ...
        }
    }

    // 커맨드 명령어 보다 event 혹은 delegate를 전달하는게 더 좋을 듯 한데?
    public class FireCommand : Command
    {
        public void Execute()
        {
            Fire();
        }

        private void Fire()
        {
            // Fire ....
        }
    }

    public class Stack<T>
    {
        T[] objList;
        int pos;

        public Stack(int size)
        {
            objList = new T[size];
        }

        public void Push(T newValue)
        {
            objList[pos++] = newValue;
        }

        public T Pop()
        {
            return objList[--pos];
        }
    }

    public class TwoGeneric<K, V>
    {
        K key;
        V value;

        public void Set(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
    }

    public class Utility
    {
        public static T Max<T>(T op1, T op2) where T : IComparable<T>
        {
            if (op1.CompareTo(op2) >= 0)
            {
                return op1;
            }

            return op2;
        }

        public static T Allocate<T, V>() where V : T, new()
        {
            return new V();
        }
    }

    class FileLogger : IDisposable
    {
        FileStream fs;

        public FileLogger(string fileName)
        {
            fs = new FileStream(fileName + ".txt", FileMode.Create);
        }

        public void Write(string txt)
        {
            fs.Write(Encoding.UTF8.GetBytes(txt), 0, txt.Length);
        }

        public void Dispose()
        {
            fs.Close();
        }
    }

    public class Base { }

    public class Derived : Base { }

    class ArrayNoException<T>
    {
        int size;
        T[] items;

        public ArrayNoException(int size)
        {
            this.size = size;
            items = new T[size];
        }

        public T this[int index]
        {
            get
            {
                if (index >= size)
                {
                    return default(T);
                }

                return items[index];
            }

            set
            {
                if (index >= size)
                {
                    return;
                }

                items[index] = value;
            }
        }
    }

    public class NaturalNumber : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new NaturalNumberEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new NaturalNumberEnumerator();
        }

        public class NaturalNumberEnumerator : IEnumerator<int>
        {
            int current;

            public int Current
            {
                get { return current; }
            }

            object IEnumerator.Current
            {
                get { return current; }
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                current++;
                return true;
            }

            public void Reset()
            {
                current = 0;
            }
        }
    }

    public class SimpleTest
    {
        int id;
        string name;

        public SimpleTest(int id)
        {
            this.id = id;
            this.name = string.Empty;
        }

        public int Id { get; set; }
    }
}
