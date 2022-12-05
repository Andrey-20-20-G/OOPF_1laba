using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOPF_1laba.Part_2
{
    internal class MainClassForTheSecondEx
    {
        private void TryExecuteTaskInlineTesting(Task[] tasks, TaskScheduler scheduler)
        {
            for(int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task<int>(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"Задача {Task.CurrentId} сработала в {Thread.CurrentThread.ManagedThreadId}-ом потоке");
                    return 1;
                });
            }

            foreach(var task in tasks)
            {
                task.Start(scheduler);
                task.Wait();
            }
        }

        public void MyMain_Part2()
        {
            Console.WriteLine($"Дефолтный поток для main: {Thread.CurrentThread.ManagedThreadId}");

            Task[] tasks = new Task[7];
            MyTaskScheduler myTaskScheduler = new MyTaskScheduler();
            QueueTaskTesting(tasks, myTaskScheduler);
            TryExecuteTaskInlineTesting(tasks, myTaskScheduler);
            TryDequeueTesting(tasks, myTaskScheduler);
            
            try
            {
                Task.WaitAll(tasks);
            }
            catch
            {
                Console.WriteLine("Несколько задач сейчас прерваны");
            }
            finally
            {
                Console.WriteLine("_____________________ Main отработал!!! _____________________");
            }
            Console.ReadLine();
        }

        private void TryDequeueTesting(Task[] tasks, MyTaskScheduler myTaskScheduler)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken cancellationToken = cts.Token;

            cts.CancelAfter(600);

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"Задача {Task.CurrentId} сработала в {Thread.CurrentThread.ManagedThreadId}-ом потоке");
                    
                }, cancellationToken);
            }

        }

        private void QueueTaskTesting(Task[] tasks, MyTaskScheduler myTaskScheduler)
        {
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task<int>(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine($"Задача {Task.CurrentId} сработала в {Thread.CurrentThread.ManagedThreadId}-ом потоке");
                    return 1;
                });
                tasks[i].Start(myTaskScheduler);
            }
        }


    }
}
