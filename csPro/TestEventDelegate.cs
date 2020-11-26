using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 通过练习一个简单的事件委托，来好好理解概念
/// http://www.tracefact.net/tech/009.html
/// </summary>
namespace csPro
{
    //定义委托，它定义了可以代表的方法的类型
    public delegate void GreetingDelegate(string name);
    class TestEventDelegate
    {
        public static void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }
        public static void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning,{0}",name);
        }
        public static void ChineseGreeting(string name)
        {
            Console.WriteLine("欢迎，{0}",name);
        }
        static void Main(string[] args)
        {
            //TestEventDelegate t = new TestEventDelegate();
            //t.EnglishGreeting("mumu");
            //t.GreetPeople("Jim", TestEventDelegate.EnglishGreeting("mymy"));
            GreetPeople("jim", EnglishGreeting);
            GreetPeople("jim", ChineseGreeting);
            Console.ReadLine();
        }
    }
}
