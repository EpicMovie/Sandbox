using System;
using System.Text;
using System.Text.RegularExpressions;

public class EncodingPrac
{
    public void Run_Encoding()
    {
        string textData = "Hello World";

        byte[] buf = Encoding.UTF8.GetBytes(textData);

        string data = Encoding.UTF8.GetString(buf);
    }

    public void Run_Regex()
    {
        string text = "Hello, World! Welcome to my world!";

        Regex regex = new Regex("world", RegexOptions.IgnoreCase);

        string result = regex.Replace(text, funcMatch);

        Console.WriteLine(result);
    }

    private bool IsEmail(string email)
    {
        Regex regex = new Regex(@"^([0-9a-zA-Z]+)@([0-9a-zA-Z]+)(\.[0-9a-zA-Z]+){1,}$");

        return regex.IsMatch(email);
    }

    private string funcMatch(Match match)
    {
        return "Universe";
    }
}