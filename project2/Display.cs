using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project2
{
    internal class Display:Area
    {
        public void Displayarea(int sqside,int rectlen,int rectbred,int rhombd1, int rhombd2)
        {
            
            Square(sqside,sqside);
            Rectangle(rectlen,rectbred);
            Rhombus(rhombd1,rhombd2);
        }
    }
}
