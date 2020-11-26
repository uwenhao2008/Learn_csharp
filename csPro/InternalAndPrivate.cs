using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace csPro
{
    class Shape 
    {
        protected int height;
        protected int length;
        public void setHeight(int h)
        {
            height = h;
        } public void setlength(int l)
        {
            length = l;
        }
    }
    class Rectangle:Shape
    {
        public int getArea()
        {
            return height * length;
        }
        public void Display()
        {
            Console.WriteLine("height{0}*length{1}={2}",height,length,getArea());
        }
    }
    
    class InternalAndPrivate
    {
        internal float iHeight;
        internal float ilength;
        public void IDosplay()
        {
            Console.WriteLine("internal的面积为{0}",iHeight*ilength);
        }

        private float pHeight;
        private float pLength;
        static void Main(string[] args)
        {
            InternalAndPrivate inp = new InternalAndPrivate();
            inp.iHeight = 15;
            inp.ilength = 20;
            Console.WriteLine("--->{0}",inp.iHeight);
            Console.WriteLine("<--{0}",inp.pHeight);
            inp.IDosplay();

            Rectangle rct = new Rectangle();
            rct.setHeight(15);
            rct.setlength(25);
            rct.Display();

            Console.ReadLine();
        }
    }
}
