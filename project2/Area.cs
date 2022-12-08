using project2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    internal class Area:Arithematic
    {
        public void Rectangle(int fno, int sno)
        {
            int result =  Mul(fno , sno);
            Console.WriteLine("rect=" +result);
           
        }
        public void Rhombus(int fno, int sno)
        {
            int result =  (int)(0.5 * Mul(fno, sno));
            Console.WriteLine("romb=" + result);
        }
        public void Square(int fno,int sno)
        {
            int result =  Mul(fno , sno);
            Console.WriteLine("sq=" + result);
        }
    }
}
