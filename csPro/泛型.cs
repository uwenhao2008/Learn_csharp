using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class MyClass1
    {
        public void F()
        {
            Console.WriteLine("基类MyClass1钟的F()被调用了");
        }
    }
    class MyClass2 : MyClass1 { }
    class Test1<T> where T : MyClass1    //  where约束了T必须继承自MyClass1
    {
        T obj;
        public Test1(T t)
        {
            obj = t;
        }
        public void SayF()
        {
            obj.F();
        }
    }
    class Test2<T> where T : struct     // 泛型限制为 数值类型   int string等  
    {
        T obj;
        public Test2(T t)
        {
            obj = t;
        }
        public void SayF()
        {
            Console.WriteLine("此处输出为<{0}>{1}",obj.GetType() ,obj);
        }
    }

    class Test<T>
    {
        T obj;
        public void F(T t)
        {
            obj = t;
            Console.WriteLine("泛型Test的一个参数的方法F():"+t.ToString());
        }
        public void F()
        {
            Console.WriteLine("泛型的无参数方法F()");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test<Program> t1 = new Test<Program>();
            Test<string> t2 = new Test<string>();
            Test<int> t3 = new Test<int>();
            t1.F();
            t2.F("Hello");
            t3.F(10);

            MyClass1 m1 = new MyClass1();
            MyClass2 m2 = new MyClass2();
            Test1<MyClass1> tt1 = new Test1<MyClass1>(m1);
            tt1.SayF();
            Test1<MyClass2> tt2 = new Test1<MyClass2>(m2);
            tt2.SayF();

            MyClass2 m3 = new MyClass2();
            Test1 <MyClass2> tt3 = new Test1<MyClass2>(m3);
            tt3.SayF();

            Test2<int> ti1 = new Test2<int>(33);
            ti1.SayF();
            
            Test2<float> ti2 = new Test2<float>(15.2f);    // 结尾的f告诉程序这是一个float，而不是doubld   强类型转换这里一定要注意
            ti2.SayF();

            Test2<bool> ti3 = new Test2<bool>(true);    // 结尾的f告诉程序这是一个float，而不是doubld   强类型转换这里一定要注意
            ti3.SayF();


            //Test2<string> ti3 = new Test2<string>("");    // string之所以不能使用的缘故是  string是sealed（即不能被继承）
            //ti3.SayF();

            /*
             var k = "a";  
             var a0 = "User";  
             var a1 = "Id";  
             var a2 = 5;  
             var ccc = string.Format("select * from {0} where {1} = {2}", a0, a1, a2);  
             var ccb = $"select * from {a0} where {a1}={a2}";  
             */
            Console.ReadLine();
        }
    }
}
