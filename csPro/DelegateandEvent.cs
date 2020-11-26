using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    public class MyEventArgs : EventArgs
    {
        public string Value_E;
    }
    public class ClassA
    {
        public ClassA(string i)
        {
            Value_A = i;
        }
        public string Value_A;

        //定义委托
        public delegate void A_DelegateEventHander(object sender, MyEventArgs e);
        //定义委托事件
        public event A_DelegateEventHander A_Myevent;

        //触发事件
        public void NotifyTOB(string newStr)
        {
            MyEventArgs ee = new MyEventArgs();
            ee.Value_E = newStr;
            if (A_Myevent != null)
            {
                A_Myevent(this, ee);
            }

        }
        //事件处理函数
        public void change(object sender, MyEventArgs e)
        {
            this.Value_A = e.Value_E;
            Console.WriteLine("ClassB中变量Value_B已经改变为：{0}", this.Value_A);
        }
    }
    class ClassB
    {
        public ClassB(string i)
        {
            Value_B = i;
        }
        public string Value_B;

        //定义委托
        public delegate void B_DelegateEventHander(object sender, MyEventArgs e);
        //定义委托事件
        public event B_DelegateEventHander B_Myevent;

        //触发事件
        public void NotifyTOA(string newStr)
        {
            MyEventArgs ee = new MyEventArgs();
            ee.Value_E = newStr;
            if (B_Myevent != null)
            {
                B_Myevent(this, ee);
            }
        }

        //事件处理函数
        public void change(object sender, MyEventArgs e)
        {
            this.Value_B = e.Value_E;
            Console.WriteLine("ClassB中变量Value_B已经改变为：{0}", this.Value_B);
        }
    }

    class DelegateandEvent
    {
        static void Main(string[] args)
        {
            ClassA classA = new ClassA("我是A");
            ClassB classB = new ClassB("我是B");

            classA.A_Myevent += new ClassA.A_DelegateEventHander(classB.change);
            classB.B_Myevent += new ClassB.B_DelegateEventHander(classA.change);

            //不同类间成员变量的访问
            classA.NotifyTOB(classA.Value_A);
            classB.Value_B = "我是B"; //因为上一条语句已经改变了Value_B ，现在改回来以便观察下一条语句
            classB.NotifyTOA(classB.Value_B);

            //在一个类中随意修改另一个类的成员变量
            classA.NotifyTOB("我是改变的B");
            classB.NotifyTOA("我是改变的A");
            Console.ReadLine();
        }
    }
}
