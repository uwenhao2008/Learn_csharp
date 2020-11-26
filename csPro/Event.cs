using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 50行代码来理解事件
/// 女友要求男友做的事
/// </summary>
namespace Practice
{
    public delegate void Job(); // 任务列表委托
    class She
    {
        private event Job BoyFriendJobs = null; // 男朋友任务列表    
        public void Command()
        {
            if(BoyFriendJobs != null)
            {
                BoyFriendJobs();
            }
            else
            {
                Console.WriteLine("没有男友，我太难了...");
            }
        }
        public void AddJobs(Job jobs)       // 动态添加男友任务
        {
            BoyFriendJobs += jobs;
        }
    }
    class He
    {
        public void BuyTrainTicket()
        {
            Console.WriteLine("买火车票");
        }
        public void BuyCinemaTicket()
        {
            Console.WriteLine("买电影票");
        }
        public void BuyFood()
        {
            Console.WriteLine("买吃的");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            She she = new She();
            He he = new He();
            she.AddJobs(he.BuyTrainTicket);
            she.AddJobs(he.BuyCinemaTicket);
            she.AddJobs(he.BuyFood);
            she.Command();
            Console.ReadLine();
        }
    }
}
