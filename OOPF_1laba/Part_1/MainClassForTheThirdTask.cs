using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPF_1laba.Part_1
{
    internal class MainClassForTheThirdTask
    {
        public void MainMethod1()
        {
            Console.WriteLine("Запустите прогу нажатием рандомной клавиши");
            Console.ReadKey();

            int b = 0;
            var threadpool = new ThreadPoolWithResult<decimal>(SimpleMethod);
            threadpool.Run(b);

            while(threadpool.Completed == false)
            {
                Console.WriteLine("Мама мыла раму");
                Thread.Sleep(35);
            }
            Console.WriteLine($"Результат второго метода: {threadpool.Result}");
            Console.ReadLine();
        }


        private static decimal SimpleMethod(object obj)
        {
            int a = 0;
            for (int i = 1; i < 100; i += 2)
            {
                a += i*7/17;
                Thread.Sleep(3);
            }
            return a;
        }
    }
}
