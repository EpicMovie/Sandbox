using System;

public class SerializationPrac
{
    public void Run_Serialize()
    {
        byte[] boolBytes = BitConverter.GetBytes(true);
        byte[] shortBytes = BitConverter.GetBytes((short)32000);
        byte[] intBytes = BitConverter.GetBytes(1652300);

        const int START_INDEX = 0;

        bool boolResult = BitConverter.ToBoolean(boolBytes, START_INDEX);
        short shortResult = BitConverter.ToInt16(shortBytes, START_INDEX);
        int intResult = BitConverter.ToInt32(intBytes, START_INDEX);

        Console.WriteLine(BitConverter.ToString(boolBytes) + " : " + boolResult);
        Console.WriteLine(BitConverter.ToString(shortBytes) + " : " + shortResult);
        Console.WriteLine(BitConverter.ToString(intBytes) + " : " + intResult);
    }
}