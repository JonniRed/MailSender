using System;
using System.Threading;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadPoolTests.Start();
            SynchronizationTests.Start();
            Console.WriteLine("Приложение должно быть закрыто");
        }
    }   
}
