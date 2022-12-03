using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPF_1laba.Part_1
{
    internal class ThreadPoolForTheSecondTask
    {
        private readonly Action<object> action;

        public ThreadPoolForTheSecondTask(Action<object> action)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public bool Success { get; private set; } = false;
        public Exception Exeption { get; private set; }
        public bool Completed { get; private set; } = false;



        public void Run(object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadExecution), state);
        }

        public void Wait()
        {
            while (!Completed)
            {
                Thread.Sleep(1000);
            }
            if(Exeption == null)
            {
                return;
            }
            throw Exeption;
        }

        private void ThreadExecution(object state)
        {
            try
            {
                action.Invoke(state);
                Success = true;
            }
            catch (Exception ex)
            {
                Exeption = ex;
                Success = false;
            }
            finally
            {
                Completed = true;
            }
        }
    }
}
