using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPF_1laba.Part_1
{
    internal class ThreadPoolWithResult<T>
    {
        private readonly Func<object, T> func;
        private T result;


        public ThreadPoolWithResult(Func<object, T> func)
        {
            this.func = func ?? throw new ArgumentNullException(nameof(func));
            result = default;
        }

        public bool Success { get; private set; } = false;
        public Exception Exeption { get; private set; }
        public bool Completed { get; private set; } = false;


        public T Result
        {
            get 
            {
                while (!Completed)
                {
                    Thread.Sleep(1000);
                }

                return Success != false && Exeption == null ? result : throw Exeption;
            }
        }

        public void Run(object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadExecution), state);
        }

        private void ThreadExecution(object state)
        {
            try
            {
                result =  func.Invoke(state);
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
