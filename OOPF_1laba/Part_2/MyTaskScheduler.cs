using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPF_1laba.Part_2
{
    internal class MyTaskScheduler : TaskScheduler
    {
        private readonly LinkedList<Task> list = new LinkedList<Task>();

        public MyTaskScheduler()
        {
            list = new LinkedList<Task>();
        }
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return list;
        }

        protected override void QueueTask(Task task)
        {
            Console.WriteLine($"{task.Id} - эта задача теперь в очереди");
            
            list.AddLast(task);
            ThreadPool.QueueUserWorkItem(ExecuteTasks, null);
            AddTaskToTop(task);
            AddTaskToEnd(task);
            //ExecuteTasks(null);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            Console.WriteLine($"Синхронное выполнение задачи {task.Id}");

            lock (list)
            {
                list.Remove(task);
            }
            return base.TryExecuteTask(task);

        }

        protected override bool TryDequeue(Task task)
        {
            Console.WriteLine($"Удаление задачи {task.Id}");

            bool res = false;
            lock (list)
            {
                res = list.Remove(task);
            }
            if (res)
            {
                Console.WriteLine($"Задача {task.Id} была успешно удалена");
            }
            return res;
        }

        private void ExecuteTasks(object _)
        {
            while(true)
            {
                Task task = null;
                lock(list)
                {
                    if (list.Count == 0)
                        break;
                    task = list.First.Value;
                    list.RemoveFirst();
                }

                if (task == null)
                    break;
                base.TryExecuteTask(task);


            }

        }

        private void AddTaskToEnd(Task task)
        {
            var current = list.FirstOrDefault(x => x.Id == task.Id);
            if(current != null)
            {
                lock (list)
                {
                    list.AddLast(current);
                    list.Remove(list.FirstOrDefault(x=>x.Id == task.Id));
                    Console.WriteLine($"Задача {task.Id} успешно перемещена в конец");
                }
                
            }

        }

        private void AddTaskToTop(Task task)
        {
            var current = list.FirstOrDefault(x => x.Id == task.Id);
            if (current != null)
            {
                lock (list)
                {
                    list.Remove(list.FirstOrDefault(x => x.Id == task.Id));
                    list.AddFirst(current);
                    Console.WriteLine($"Задача {task.Id} успешно перемещена в начало");
                }
                
            }

        }


    }
}
