using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class Myclass
    {
        public string name { get; set; }
        public string how { get; set; }
        public Myclass(string a,string b)
        {
            name = a;
            how = b;
        }
    }
    
    class Aclass
    {
        public string NameA
        {
            get;
            set;
        }
        public int NumberA
        {
            get;
            set;
        }
        public Aclass(string a,int b)
        {
            NameA = a;
            NumberA = b;
        }
    }
    class Bclass
    {
        public int NumberB
        {
            get;
            set;
        }
        public bool stockB
        {
            get;
            set;
        }
        public Bclass(int a,bool b)
        {
            NumberB = a;
            stockB = b;
        }
    }
    class Cclass
    {
        public string NameC
        {
            get;
            set;
        }
        public bool stockC
        {
            get;
            set;
        }
        public Cclass(string a, bool b)
        {
            NameC = a;
            stockC = b;
        }
    }
    class ChrAbc
    {
        public char One;
        public char Two;
        public ChrAbc(char c1,char c2)
        {
            One = c1;
            Two = c2;
        }
    }
    
    class Student
    {
        public int id
        {
            get;
            private set;
        }
        public string name
        {
            get;
            private set;
        }
        public string gender
        {
            get;
            private set;
        }
        public int age
        {
            get;
            private set;
        }
        public Student(int a,string b,string c,int d)
        {
            id = a;
            name = b;
            gender = c;
            age = d;
        }
    }
    
    class usingLinq
    {
        static void Main(string[] args)
        {
            int[] num = { 1, 5, -9, 15, -8, 0, 6 ,2,9};
            // 找到n<0
            var ponum1 = from n in num
                        where n < 0
                        select n;
            Console.WriteLine("捕获到的负数为：");
            foreach(int i in ponum1)
            {
                Console.Write(i+" ");
            }
            Console.ReadLine();

            // 找到n在0至10之间                   //  这里的两个where是and的关系，若是写在一行就需要&&
            var ponum2 = from n in num
                         where n > 0
                         where n <= 10
                         select n;
            foreach(int i in ponum2)
            {
                Console.Write(i+" ");
            }
            Console.ReadLine();

            Console.WriteLine("进入标志位");
            var ponum3 = from n in num
                         orderby n descending    //  降序排列
                         select Math.Sqrt(n);     //  开方！！！     这里得到的   -2147483648  因为负数不能开放，超出了int的值范围
                         //select n;
            foreach (int i in ponum3)
            {
                Console.Write(i+" ");
            }
            Console.ReadLine();

            Student[] students = {
                                new Student(001,"寒月","女",20),
                                new Student(002,"烈阳","兽",2000),
                                new Student(003,"蒙玡","男",28),
                                new Student(004,"蒙恬","男",58),
                                new Student(005,"蒙括","男",68),
                                new Student(006,"飞流","女",18),
                                new Student(007,"黎明","女",8),
            };
            var cxin = from acc in students
                       orderby acc.age descending, acc.id
                       select acc;
            string str = "";
            foreach(Student acc in cxin)
            {
                if(str != acc.gender)
                {
                    Console.WriteLine();
                    str = acc.gender;
                    Console.WriteLine(str);
                }
                Console.WriteLine("{0},{1},{2},{3}",acc.id,acc.name,acc.gender,acc.age);
            }
            Console.ReadLine();

            Console.WriteLine("进入排列组合模式");
            char[] chr1 = { 'A','B','C','D'};
            char[] chr2 = { 'a','b','c','d'};
            var par = from ch1 in chr1
                      from ch2 in chr2
                      select new ChrAbc(ch1, ch2);
            foreach(var i in par)
            {
                Console.WriteLine("{0},{1}",i.One,i.Two);
            }
            Console.ReadLine();

            string[] words = { "Blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" ,"elephant","umbrella","anteater"};
            var WordGroups = from w in words
                             group w by w[0];    // 字符串可以通过下标操作
            foreach(var wordGroup in WordGroups)
            {
                Console.WriteLine("开头为'{0}'的单词为：",wordGroup.Key);   // ????? Key是什么
                foreach(var word in wordGroup)
                {
                    Console.WriteLine(word);
                }
            }
            Console.ReadLine();

            var wordGroups2 = from w in words
                              group w by w[0] into grps
                              where (grps.Key == 'a' || grps.Key == 'e' || grps.Key == 'i' || grps.Key == 'o' || grps.Key == 'u')
                              select grps;
            foreach(var wordGroup in wordGroups2)
            {
                Console.WriteLine("开头为'{0}'的单词为：",wordGroup.Key);
                foreach(var word in wordGroup)
                {
                    Console.WriteLine("{0}",word);
                }
            }
            Console.ReadLine();

            Console.WriteLine("let创建字句里的变量");
            string[] str3 = { "apple", "banana", "pear" };

            Console.WriteLine("尝试通过linq的方式直接输出数组值");
            var cha1 = from st1 in str3
                       select st1;
            foreach(string ss in cha1)
            {
                Console.Write(ss+" ");
            }
            Console.WriteLine();

            var cha = from st in str3
                      let chrArray = st.ToCharArray()
                      from ch in chrArray
                      select ch;
            Console.WriteLine("字符串中的字符为：");
            foreach(char c in cha)
            {
                Console.Write(c+" ");
            }
            Console.ReadLine();

            Console.WriteLine("使用join语句");
            Aclass[] aclass = {
                               new Aclass("小明",1245),
                               new Aclass("小丽",1546),
                               new Aclass("小章",2469),
                               new Aclass("小敏",1853),
                               new Aclass("小宏",7896),
            };
            Bclass[] bclass = { 
                               new Bclass(1245,true),
                               new Bclass(1546,false),
                               new Bclass(2469,true),
                               new Bclass(1853,false),
                               new Bclass(7896,true),
            };
            var abc = from a in aclass
                      join b in bclass
                      on a.NumberA equals b.NumberB
                      //select new Cclass(a.NameA, b.stockB);  //通过构造类来实现合并筛选序列
                      select new { Name = a.NameA, stor = b.stockB };    //  通过匿名函数来实现合并序列
            Console.WriteLine("姓名是否存在");
            //foreach(Cclass c in abc)
            foreach(var c in abc)   //  注意这里的不同
            {
                //Console.WriteLine("{0}{1}",c.NameC,c.stockC);
                Console.WriteLine("{0}{1}",c.Name,c.stor);   // 输出
            }
            Console.ReadLine();

            Console.WriteLine("创建组链接");
            string[] type = { "助教", "讲师", "教授" };
            Myclass[] myclass = {
                                new Myclass("张明1","讲师"),
                                new Myclass("张明2","教授"),
                                new Myclass("张明3","助教"),
                                new Myclass("张明4","讲师"),
                                new Myclass("张明5","教授"),
                                new Myclass("张明6","助教"),
                                new Myclass("张明7","讲师"),
                                new Myclass("张明8","助教"),
                                new Myclass("张明9","教授"),
            };
            var byhow = from t in type
                        join mc in myclass
                        on t equals mc.how
                        into lst                 //  通过lst表示列表
                        select new { how = t, Tlist = lst };
            foreach(var a in byhow)
            {
                Console.WriteLine("{0}",a.how);
                foreach(var m in a.Tlist)
                {
                    Console.WriteLine(" "+m.name);
                }
                Console.ReadLine();
            }
        }

    }
}
