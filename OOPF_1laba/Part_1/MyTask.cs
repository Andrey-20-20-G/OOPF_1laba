using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPF_1laba.Part_1
{
    internal class MyTask
    {

        public void MyMain()
        {
            Action met1 = new Action(Method1);

            Console.WriteLine("Вывод с помощью создания класса Task");
            Task task = new Task(met1);
            task.Start();
            Method2();

            Console.WriteLine("\nВывод с помощью TaskFactory");
            TaskFactory taskFactory = new TaskFactory();
            taskFactory.StartNew(Method1);
            Method2();

            Console.WriteLine("\nВывод с помощью метода Run");
            Task.Run(met1);
            Method2();

            Console.WriteLine("\nСинхронный вывод");
            task = new Task(met1);
            task.RunSynchronously();
            Method2();

            Console.ReadKey();

            
        }
        private static void Method1()
        {
            for(int i = 0; i < 50; i++)
            {
                string chr = i % 2 > 0 ? "h" : "a";
                Console.Write(chr);
                Thread.Sleep(100);
            }
            
        }

        private static void Method2()
        {
            for (int i = 0; i < 50; i++)
            {
                string chr = i % 2 > 0 ? "h" : "i";
                Console.Write(chr);
                Thread.Sleep(100);
            }
            
        }


    }
}
