using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLib;
namespace Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph.Create(new DomainFunc(TypeDomain.REAL, -1000, 1000), x => (x * x) + 50 * x + 10, new Graph.GraphInfo("Funkcja kwadratowa", "Os X", "Os Y", GraphTypes.LINE));
           
        }
        

        
    }
}
