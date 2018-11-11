using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    class basic
    {
        public static double power(double x,double n)
        {
            if (n == 0)
                return 1;
            
            if (n % 2 == 1)
            {
                
                return x * power(x, n - 1);
            }
            double y = power(x, n / 2);
            return y*y;
        }
        
    }
   
}
