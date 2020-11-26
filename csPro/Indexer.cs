using System;
namespace IndexerApplication
{
    /*
    class IndexedNames
    {
        private string[] namelist = new string[size];
        static public int size = 10;
        public IndexedNames()          //  这里是构造函数，所以没有返回值，函数一定要有返回值，没有的话就是void
        {
            for (int i = 0; i < size; i++)
            {
                namelist[i] = "N. A.";
            }
        }
        public string this[int index]
        {
            get
            {
                string tmp;

                if (index >= 0 && index <= size - 1)
                {
                    tmp = namelist[index];
                }
                else
                {
                    tmp = "";
                }

                return (tmp);
            }
            set
            {
                if (index >= 0 && index <= size - 1)
                {
                    namelist[index] = value;
                }
            }
        }
        public int this[string name]
        {
            get
            {
                int index = 0;
                while (index < size)
                {
                    if (namelist[index] == name)
                    {
                        return index;
                    }
                    index++;
                }
                return index;
            }

        }

        static void Main(string[] args)
        {
            IndexedNames names = new IndexedNames();
            names[0] = "Zara";
            names[1] = "Riz";
            names[2] = "Nuha";
            names[3] = "Asif";
            names[4] = "Davinder";
            names[5] = "Sunil";
            names[6] = "Rubic";
            // 使用带有 int 参数的第一个索引器
            for (int i = 0; i < IndexedNames.size; i++)
            {
                Console.WriteLine(names[i]);
            }
            // 使用带有 string 参数的第二个索引器
            Console.WriteLine(names["Asif"]);
            Console.WriteLine(names["Nuha"]);    //  重载了索引器
            Console.ReadKey();
        }
    }
    */
    /*
    public class IndexedNames
    {
        private string[] nameList;
        public int size;
        public IndexedNames(int size)
        {
            this.size = size;
            nameList = new string[size];
            for (int i = 0; i < size; i++)
            {
                nameList[i] = "N. A.";
            }
        }
        public string this[int index]
        {
            get
            {
                string temp;
                if (index >= 0 && index < size)
                {
                    temp = nameList[index];
                }
                else
                {
                    temp = "";
                }
                return temp;
            }
            set
            {
                if (index >= 0 && index < size)
                {
                    nameList[index] = value;
                }
            }
        }
        static void Main(string[] args)
        {
            IndexedNames index = new IndexedNames(5);
            index[0] = "Zara";
            index[1] = "Riz";
            index[2] = "Nuha";
            index[3] = "Asif";
            index[4] = "Davinder";
            for (int i = 0; i < index.size; i++)
            {
                Console.WriteLine(index[i]);
            }
            Console.ReadKey();
        }
        
    }*/
    class Employee
    {
        public string firstName;
        public string middleName;
        public string lastName;

        public string this[string index]
        {
            set
            {
                switch (index)
                {
                    case "a":
                        firstName = value;
                        break;
                    case "b":
                        middleName = value;
                        break;
                    case "c":
                        lastName = value;
                        break;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
            get
            {
                switch (index)
                {
                    case "a": return firstName;
                    case "b": return middleName;
                    case "c": return lastName;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
        }

        static void Main(string[] args)
        {
            Employee ee = new Employee();

            ee.firstName = "胡";
            ee.middleName = "大";
            ee.lastName = "阳";

            Console.WriteLine("我的名字叫: {0}{1}{2}", ee["a"], ee["b"], ee["c"]);
            Console.ReadLine();
        }
    }
}
