using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskExample
{
    class Program
    {
        private static object s_logLock = new object();
        static void Main(string[] args)
        {
            TasksUsingThreadPool();

            Console.WriteLine("\nTask with result:\n");
            TaskWithResultDemo();

            Console.WriteLine("\nTask continuation:\n");
            ContinuationTasks();

            Console.ReadKey();
        }

       
        public static void TasksUsingThreadPool()
        {

            var tf = new TaskFactory();
            Task t1 = tf.StartNew(TaskMethod, "using a task factory");
            Task t2 = Task.Factory.StartNew(TaskMethod, "factory via a task");
            var t3 = new Task(TaskMethod, "using a task constructor and Start");
            t3.Start();
            Task t4 = Task.Run(() => TaskMethod("using the Run method"));
        }

        public static void TaskMethod(object o)
        {
            Log(o?.ToString());
        }

        public static void Log(string title)
        {

            lock (s_logLock)
            {
                Console.WriteLine(title);
                Console.WriteLine($"Task id: {Task.CurrentId?.ToString() ?? "no task"}, thread: {Thread.CurrentThread.ManagedThreadId}");


                Console.WriteLine($"is background thread: {Thread.CurrentThread.IsBackground}");
                Console.WriteLine();
            }
        }


        public static void TaskWithResultDemo()
        {
            var t1 = new Task<Tuple<int, int>>(TaskWithResult, Tuple.Create(8, 3));
            t1.Start();
            Console.WriteLine(t1.Result);
            t1.Wait();
            Console.WriteLine($"result from task: {t1.Result.Item1} {t1.Result.Item2}");
        }
        private static Tuple<int, int> TaskWithResult(object division)
        {
            Tuple<int, int> div = (Tuple<int, int>)division;
            int result = div.Item1 / div.Item2;
            int reminder = div.Item1 % div.Item2;
            Console.WriteLine("task creates a result...");

            return Tuple.Create(result, reminder);
        }

        public static void ContinuationTasks()
        {

            Task t1 = new Task(DoOnFirst);
            Task t2 = t1.ContinueWith(DoOnSecond);
            Task t3 = t1.ContinueWith(DoOnSecond);
            Task t4 = t2.ContinueWith(DoOnSecond);
            t1.Start();
        }

        private static void DoOnFirst()
        {
            Console.WriteLine($"doing some task {Task.CurrentId}");
            Task.Delay(3000).Wait();
        }

        private static void DoOnSecond(Task t)
        {
            Console.WriteLine($"task {t.Id} finished");
            Console.WriteLine($"this task id {Task.CurrentId}");
            Console.WriteLine("do some cleanup");
            Task.Delay(3000).Wait();
        }
    }
}
