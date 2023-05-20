using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yandex.Music.SourceGenerators.Tests
{
    /// <summary>
    /// Установка текущего индекса проигрываемого трека в очереди треков
    /// </summary>
    /// <param name="storage">Хранилище</param>
    /// <param name="queueId">Идентификатор очереди</param>
    /// <param name="currentIndex">Текущий индекс</param>
    /// <param name="isInteractive">Флаг интерактивности <see cref="Program"/></param>
    /// <param name="device">Устройство</param>
    /// <returns></returns>
    [GenerateSync]
    public partial class TestClass
    {
        public Task<List<bool>> AnotherPrintNumberAsync(int number, params string[] names)
        {
            Console.WriteLine(number);
            return Task.FromResult(new List<bool> { true });
        }

        /// <summary>
        /// Комментарий
        /// </summary>
        /// <param name="number"></param>
        /// <param name="on"></param>
        public Task<bool> BoolPrintNumberAsync(int number, string on = "", bool off = true)
        {
            Console.WriteLine(number);
            return Task.FromResult(Convert.ToBoolean(on));
        }

        public Task TaskPrintNumberAsync(int number, List<Task> tasks)
        {
            Console.WriteLine(number);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Комментарий
        /// </summary>
        /// <param name="number"></param>
        public void PrintNumber(int number)
        {
            List<int> ints = new int[] { 12, 15, 13 }
                .Where(n => n > 12)
                .ToList();

            Console.WriteLine(number);
        }
    }
}