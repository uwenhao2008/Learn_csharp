using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro.Modifier
{
    class A
    {
        public virtual void PrintFields()
        {
            Console.WriteLine("我是A的方法");
        }
    }
    class B : A
    {
        public override void PrintFields()   // virtual其实就是为了实现类继承之间方法的重载吧，不至于出现相同类型的方法名被占用而导致的func1,2,3,4...这种情况
        {
            Console.WriteLine("我是B的方法");
            base.PrintFields();
        }
    }
    class VirtualFunction
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            a.PrintFields();
            b.PrintFields();
            Console.ReadLine();
        }
    }
}
