using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string fileName = "D:\\channels.conf.org";
            Console.WriteLine(Path.GetFileName(fileName));
            Console.WriteLine(Path.GetFileNameWithoutExtension(fileName));
            Console.WriteLine(Path.GetExtension(fileName));

            Console.ReadKey();
        }
    }
}
