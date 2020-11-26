using System;
using System.Runtime.CompilerServices;

delegate void NumberChanger(int n);
namespace DelegateAppl
{
    class TestData
    {
        int n = 12;
        public void AddNum(int p)
        {
            n += p;
            Console.WriteLine("实例化后，num为：{0}", n);
        }
        public int GetItem()
        {
            return n;
        }
    }
    
    class TestDelegate
    {
        static int num = 10;
        public static void AddNum(int p)
        {
            num += p;
            Console.WriteLine("Named Method: {0}", num);
        }

        public static void MultNum(int q)
        {
            num *= q;
            Console.WriteLine("Named Method: {0}", num);
        }

        static void Main(string[] args)
        {
            // 使用匿名方法创建委托实例
            NumberChanger nc = delegate (int x)
            {
                Console.WriteLine("Anonymous Method: {0}", x);
            };

            // 使用匿名方法调用委托
            nc(10);

            // 使用命名方法实例化委托
            nc = new NumberChanger(AddNum);

            // 使用命名方法调用委托
            nc(5);

            // 使用另一个命名方法实例化委托
            nc = new NumberChanger(MultNum);
            Console.WriteLine("此时的num已经从10变为：{0}",num);   //  num参数一定要是静态的才可以，因为类没有实例化

            // 使用命名方法调用委托
            nc(2);

            // 通过实例化类TestDelegate，来看num状态    实例化以后n的值就独立开了
            TestData t1 = new TestData();
            TestData t2 = new TestData();
            t1.AddNum(5);
            Console.WriteLine("--->此时的n为：{0}",t1.GetItem());
            t2.AddNum(20);
            Console.WriteLine(">>>>此时的n为：{0}", t2.GetItem());
            Console.ReadKey();
        }
    }
}