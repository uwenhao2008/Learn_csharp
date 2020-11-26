using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class Person
    {
        public string ID;
        public PerInfo perinfo;
    }
    class PerInfo
    {
        public string pName { get; set; }
        public string pSex { get; set; }
        public PerInfo(string name,string sex)
        {
            this.pName = name;
            this.pSex = sex;
        }
    }

    class PersonArr
    {
        public string ID;
        public PerInfo[] perinfo;
    }

    class addDataInClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("通过构造函数实现单个赋值");
            Person p = new Person();
            p.ID = "15";
            p.perinfo = new PerInfo("wen","male");
            Console.ReadLine();

            Console.WriteLine("通过构造函数实现类数组的赋值");
            PersonArr pa = new PersonArr();
            pa.perinfo = new PerInfo[2];   // 创建一个长度为2的数组
            pa.perinfo[0] = new PerInfo("wenhao", "male");
            pa.perinfo[1] = new PerInfo("wenhao1", "male1");
            Console.ReadLine();
            //  终于把类里嵌套类的赋值方式写出来了
        }
    }
    
}
