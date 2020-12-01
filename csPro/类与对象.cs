using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class Cperson
    {
        private string myName;
        public string Name
        {
            get { return myName+"--"; }
            set { myName = value; }
        }
        static void Main(string[] args)
        {
            Cperson tom = new Cperson();
            tom.Name = "Tom";
            Console.WriteLine(tom.Name);
            Console.WriteLine(tom.myName);
            Console.ReadLine();
        }
    }
}
