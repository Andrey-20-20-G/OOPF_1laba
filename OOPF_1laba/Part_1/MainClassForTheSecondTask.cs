using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPF_1laba.Part_1
{
    internal class MainClassForTheSecondTask
    {
        public void MainMethod1()
        {
            
            Console.WriteLine("Вывод четных чисел означает выполнение 2-го потока");
            Console.WriteLine("Вывод нечетных чисел означает выполнение 1-го потока \n\n");
            Console.WriteLine("Запустите прогу нажатием рандомной клавиши");
            Console.ReadKey();
            
            int b = 0;
            var threadpool = new ThreadPoolForTheSecondTask(new Action<object>(SimpleMethod));
            threadpool.Run(b);

            for (int i = 0; i < 100; i += 2)
            {
                Console.Write($"{b+i} ");
                Thread.Sleep(50);
            }
            
            Console.ReadLine();

        }


        private static void SimpleMethod(object obj)
        {
            int a = 0;
            for (int i = 1; i < 100; i += 2)
            {
                Console.Write($"{a + i} ");
                Thread.Sleep(50);
            }
        }
    }
}
