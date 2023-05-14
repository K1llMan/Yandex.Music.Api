using System;
using System.Threading.Tasks;

namespace Yandex.Music.SourceGenerators.Tests
{
    partial class Program
    {
        static async Task Main(string[] args)
        {
            await PrintNumberAsync(42);
            Console.ReadLine();
        }

        [Asyncify]
        static void PrintNumber(int number)
        {
            Console.WriteLine(number);
        }
    }
}
