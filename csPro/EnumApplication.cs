using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class EnumApplication
    {
        private int count = 0;
        //构造函数  创建类新对象时候自动执行
        public EnumApplication()
        {
            count++;  //  每次实例化都重置count为0了
            Console.WriteLine("这是你第{0}个实例化的类",count);
        }
        public void CountClass()
        {
            for (int i = 0; i < 10; i++)
            {
                EnumApplication str = new EnumApplication();
            }
        }

        enum Days { Sun, Mon=7, Tue, Wed, Thu=18, Fri, Sat }
        public void EnumData() {
            int x = (int)Days.Sun;   //  (int)这里是强制转换
            byte y = (byte)Days.Mon;
            int z = (int)Days.Fri;   //  19，因为Thu是18
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
        }

        // 判断用户的增删改查权限
        [Flags]   //  输出显示为Create，Read等，而不是数字
        enum Permission
        {
            Create=1,
            Read=2,
            Update=4,
            Delete=8

        }
        public void JudgePermission()
        {
            Permission permission = Permission.Create | Permission.Read | Permission.Update | Permission.Delete;
            Console.WriteLine(permission);
            //去掉用户的 Create and Update
            permission = permission & ~Permission.Update;
            Console.WriteLine("用户失去Update以后权限为{0}",permission);
            //判断用户是否有Update权限
            bool isUpdate = (permission & Permission.Update) != 0;
            Console.WriteLine(isUpdate);
            if (isUpdate)
            {
                Console.WriteLine("用户有{0}权限",Permission.Update);
            }
            else
            {
                Console.WriteLine("该用户没有{0}权限");
            }
        }

        static void Main(string[] args)
        {
            EnumApplication app = new EnumApplication();
            app.EnumData();
            app.JudgePermission();
            app.CountClass();
            Console.ReadLine();
        }
    }
}
