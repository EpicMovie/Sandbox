using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class FileStreamPrac
{
    public void Run_FileStream()
    {
        SimpleFileStream();
    }

    private void SimpleFileStream()
    {
        using (FileStream fs = new FileStream("test.log", FileMode.Create))
        {
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            sw.WriteLine("Hello World");
            sw.WriteLine("Anderson");
            sw.Write(10000);
            sw.Flush();
        }

        using(FileStream fs = new FileStream("test2.log", FileMode.Create))
        {
            BinaryWriter bw = new BinaryWriter(fs);

            bw.Write("Hello World" + Environment.NewLine);
            bw.Write("Handerson" + Environment.NewLine);
            bw.Write(23000);
            bw.Flush();
        }
    }
}
