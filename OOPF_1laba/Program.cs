using OOPF_1laba.Part_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPF_1laba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Вывод на экран символов в разных потоках с использованием Thread
            var threadForTheFirstTask = new ThreadForTheFirstTask();
            threadForTheFirstTask.MainMethod1();
            #endregion
            #region Обертка для ThreadPool
            var mainClass = new MainClassForTheSecondTask();
            mainClass.MainMethod1();
            #endregion
            #region Обертка для ThreadPool с результатом
            var mainClass3 = new MainClassForTheThirdTask();
            mainClass3.MainMethod1();
            #endregion

            #region Работа с Task
            var myTask = new MyTask();
            myTask.MyMain();
            #endregion
        }
    }
}
