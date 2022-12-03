using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPF_1laba.Part_1
{
    internal class ThreadForTheFirstTask
    {
        public void MainMethod1()
        {
            var thread = new Thread(SimpleMethod);
            Console.WriteLine("Вывод четных чисел означает выполнение 2-го потока");
            Console.WriteLine("Вывод нечетных чисел означает выполнение 1-го потока \n\n");
            Console.WriteLine("Запустите прогу нажатием рандомной клавиши");
            Console.ReadKey();
            thread.Start();

            for (int i = 1; i < 100; i += 2)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }


        private static void SimpleMethod()
        {
            
            for(int i = 0; i < 100; i+=2)
            {
                Console.WriteLine($"\t\t{i}");
            }
        }
    }
}
