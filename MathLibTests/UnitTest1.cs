using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathLib;
using System.Diagnostics;
namespace TestingLib
{



    [TestClass]
    public class MatrixTest
    {
        

        [TestInitialize]
        public void MainTest()
        {
            Matrix A = new Matrix(new double[][] {//2x2
                new double[] {1,2},
                new double[] {3,4},
            });//2x2
            Matrix B = new Matrix(new double[][] {
                new double[] {10,9},
                new double[] {7,4},
            });//2x2
          
            #region adding
            Matrix resultAddAAndB=new Matrix(new double[][] {//2x2
                new double[] {11,11},
                new double[] {10,8},
            });
            //throw new Exception("Error in Adding A and B. Result is " + A + B);

            #endregion
            
        }
    }
}
