using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    /// <summary>
    /// 购票机：主要显示总票数，余票
    /// </summary>
    class TicketService
    {
        public int TotalTicket = 20; // 总票数
        public int doTic;
        //定义委托
        public delegate void PersonActHandler(int buyNum);
        //定义事件
        public event PersonActHandler PeronEvent;
        public void SellTic(int n)
        {
            if (TotalTicket > 0)
            {
                TotalTicket -= n;
                Console.WriteLine("卖出去了{0}张票，还剩下{1}张票",n,TotalTicket);
            }
            else
            {
                Console.WriteLine("无票可买~~~");
            }
        }
        public void CancelTic(int n)
        {
            TotalTicket += n;
            Console.WriteLine("乘客退回了{0}张票，现在余票{1}",n,TotalTicket);
        }
        
        public void DoTicketAction()
        {
            if (PeronEvent!=null)
            {
                PeronEvent(doTic);
            }
        }
    }

    /// <summary>
    /// 购票人信息：姓名，性别，年龄，购买张数，购买事件
    /// </summary>
    class Personinfo
    {
        public  Personinfo(string name,string sex,int age, int buyNum)
        {
            this.name = name;
            this.sex = sex;
            this.age = age;
            this.buyNum = buyNum;
        }
        public string name, sex;
        public int age, buyNum;
    }

    class TrainTicketTest
    {
        static void Main(string[] args)
        {
            Personinfo p1 = new Personinfo("文雷","男",37,5);
            Personinfo p2 = new Personinfo("文浩","男",33,3);
            TicketService ts = new TicketService();
            ts.doTic = p1.buyNum;
            ts.PeronEvent += ts.SellTic;
            ts.doTic = p2.buyNum;   
            ts.PeronEvent += ts.CancelTic;
            ts.DoTicketAction();  // 因为是合并后的事件一起执行的，所以70行设置的参数不去作用了
            Console.ReadLine();
        }
    }
}
