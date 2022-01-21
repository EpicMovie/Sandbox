using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

[Serializable]
public class SerializeClass
{
    public SerializeClass() { }

    public SerializeClass(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public int a;
    public int b;
}

public class MemStreamPrac
{
    public void Run_MemStream()
    {
        MemStreamReadWrite();
        BinarySerialize();
        XMLSerialize();
        JsonSerialize();
    }

    private void MemStreamReadWrite()
    {
        byte[] shortBytes = BitConverter.GetBytes((short)32000);
        byte[] intBytes = BitConverter.GetBytes(1652300);

        MemoryStream ms = new MemoryStream();

        ms.Write(shortBytes, 0, shortBytes.Length);
        ms.Write(intBytes, 0, intBytes.Length);

        ms.Position = 0;

        byte[] outBytes = new byte[2];

        ms.Read(outBytes, 0, 2);

        int shortResult = BitConverter.ToInt16(outBytes, 0);

        Console.WriteLine(shortResult);

        outBytes = new byte[4];

        ms.Read(outBytes, 0, 4);

        int intResult = BitConverter.ToInt32(outBytes, 0);

        Console.WriteLine(intResult);

        byte[] buf = Encoding.UTF8.GetBytes("Hello World");

        ms.Write(buf, 0, buf.Length);

        StreamWriter sw = new StreamWriter(ms, Encoding.UTF8);

        sw.WriteLine("Hello World");
        sw.WriteLine("Anderson");
        sw.WriteLine(32000);
        sw.Flush();

        ms.Position = 0;

        StreamReader sr = new StreamReader(ms, Encoding.UTF8);

        string txt = sr.ReadToEnd();

        Console.WriteLine(txt);
    }

    private void BinarySerialize()
    {
        SerializeClass sc = new SerializeClass(10, 5);

        BinaryFormatter bf = new BinaryFormatter();

        MemoryStream ms = new MemoryStream();

        bf.Serialize(ms, sc);

        ms.Position = 0;

        SerializeClass clone = bf.Deserialize(ms) as SerializeClass;

        Console.WriteLine(clone);
    }

    private void XMLSerialize()
    {
        MemoryStream ms = new MemoryStream();

        XmlSerializer xs = new XmlSerializer(typeof(SerializeClass));

        SerializeClass sc = new SerializeClass(10, 20);

        xs.Serialize(ms, sc);

        byte[] arr = ms.ToArray();
        Console.WriteLine(Encoding.UTF8.GetString(arr));

        ms.Position = 0;

        SerializeClass clone = xs.Deserialize(ms) as SerializeClass;

        Console.WriteLine(clone);
    }

    private void JsonSerialize()
    {
        DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(SerializeClass));

        MemoryStream ms = new MemoryStream();

        SerializeClass sc = new SerializeClass(10, 20);

        dcjs.WriteObject(ms, sc);

        byte[] arr = ms.ToArray();
        Console.WriteLine(Encoding.UTF8.GetString(arr));

        ms.Position = 0;

        SerializeClass clone = dcjs.ReadObject(ms) as SerializeClass;

        Console.WriteLine(clone);
    }
}



