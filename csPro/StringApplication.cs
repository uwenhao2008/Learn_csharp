using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class StringApplication
    {
        public void StrSolution1()
        {
            string name, sex;
            name = "Wen";
            sex = "Female";
            Console.WriteLine("用户姓{0},性别{1}",name ,sex );

            char[] letters = { 'H', 'e', 'l', 'l', 'o' };
            Console.WriteLine("拼接以后的结果{0}：",new string(letters));

            string[] lang = { "Wen", "study", "very", "hard", "is", "not", "True" };
            Console.WriteLine("拼接后的句子：{0}",string.Join(" ",lang));
            Console.WriteLine("拼接后的句子长度为：{0}",string.Join(" ",lang).Length);

            string str1, str2;
            str1 = "H212ello";
            str2 = "ello";
            int sNum;
            sNum = string.Compare(str1, str2);
            Console.WriteLine(sNum);
            if (sNum == 0)
            {
                Console.WriteLine("str1与str2是否相等？");
            }
            else
            {
                Console.WriteLine("不等");
            }
        }


        static void Main(string[] args)
        {
            StringApplication str = new StringApplication();
            str.StrSolution1();
            Console.ReadLine();
        }
    }
}
