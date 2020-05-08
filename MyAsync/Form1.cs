using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"当前线程ID:{Thread.CurrentThread.ManagedThreadId}");


            #region
            //List<String> list = new List<string>();

            //ThreadPool.SetMaxThreads(8, 8);

            //List<Task> taskList = new List<Task>();


            //{
            //    Stopwatch sp = new Stopwatch();
            //    sp.Start();
            //    Console.WriteLine("Sleep之前");
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Sleep之后");
            //    sp.Stop();
            //    Console.WriteLine($"sleep耗时间{sp.ElapsedMilliseconds}");
            //}

            //{
            //    Stopwatch sp = new Stopwatch();
            //    sp.Start();
            //    Console.WriteLine("Delay之前");
            //    Task.Delay(2000).ContinueWith(t => { });
            //    Console.WriteLine("Delay之后");
            //    sp.Stop();
            //    Console.WriteLine($"Delay耗时间{sp.ElapsedMilliseconds}");
            //}

            //for (int i = 0; i < 100; i++)
            //{
            //    var k = i;
            //    taskList.Add( Task.Run(() =>
            //    {
            //        Console.WriteLine($"this is {k} running threadid = {Thread.CurrentThread.ManagedThreadId}");
            //        if (!list.Contains(Thread.CurrentThread.ManagedThreadId + ""))
            //        {
            //            list.Add(Thread.CurrentThread.ManagedThreadId + "");
            //        }
            //        Thread.Sleep(1000);
            //    }));
            //}
            //Task.WaitAll(taskList.ToArray());
            //Console.WriteLine("1111" + string.Join(",", list.ToArray()));
            #endregion

            Console.WriteLine();
            Console.WriteLine("Eleven开启了一学期的课程");
            this.Teach("lesion1");
            this.Teach("lesion2");
            this.Teach("lesion3");
            Console.WriteLine("部署一下项目实战作业，需要多人合作完成");

            TaskFactory taskFactory = new TaskFactory();
            taskFactory.StartNew(() => { });

        }
        private void Teach(string lesson)
        {
            Console.WriteLine($"{lesson}开始讲。。。");
            //long lResult = 0;
            //for (int i = 0; i < 1_000_000_000; i++)
            //{
            //    lResult += i;
            //}
            Console.WriteLine($"{lesson}讲完了。。。");
        }
        private void Coding(string name, string projectName)
        {
            Console.WriteLine($"****************Coding Start  {name} {projectName}  {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }

            Console.WriteLine($"****************Coding   End  {name} {projectName} {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {lResult}***************");
        }

        private void DoSomethingLong(string name)
        {
            Console.WriteLine($"****************DoSomethingLong Start  {name}  {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}***************");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }
            //Thread.Sleep(2000);

            Console.WriteLine($"****************DoSomethingLong   End  {name}  {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} {lResult}***************");
        }
    }
}
