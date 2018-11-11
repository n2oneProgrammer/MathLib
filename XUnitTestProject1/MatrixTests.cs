using System;
using Xunit;
using MathLib;
namespace MatrixTests
{
    public class AddingTests
    {
        Matrix A = new Matrix(new double[][] {//2x2
                new double[] {1,2},
                new double[] {3,4},
            });//2x2
        Matrix B = new Matrix(new double[][] {
                new double[] {10,9},
                new double[] {7,4},
            });//2x2
        Matrix C = new Matrix(new double[][] {
                new double[] {10,9,8},
                new double[] {7,4,7},
            });//2x3
        Matrix D = new Matrix(new double[][] {
                new double[] {10,9,50},
                new double[] {7,4,-50},
                
            });//2x3
        
        [Fact]
        public void A_and_B()
        {    
            Matrix result = new Matrix(new double[][] {//2x2
                new double[] {11,11},
                new double[] {10,8},
            });
            TestAddMatrix(A, B, result);
        }
        [Fact]
        public void C_and_D()
        {
            Matrix result= new Matrix(new double[][] {//2x2
                new double[] {20,18,58},
                new double[] {14,8,-43},
            });
            TestAddMatrix(C, D, result);
        }
        
        void TestAddMatrix(Matrix A,Matrix B,Matrix TestMatrix)
        {
           if (A + B != TestMatrix) throw new Exception("Error in Adding. Result is " + A + B);
        }

    }
    public class Multiplication
    {
        Matrix A = new Matrix(new double[][] {
            new double[] {3,10},
            new double[] {1,3}
        });
        Matrix B = new Matrix(new double[][] {
            new double[] {10,10},
            new double[] {10,10}
        });
        Matrix C = new Matrix(new double[][] {
            new double[] {3,2,0},
            new double[] {1,2,10}
        });
        Matrix D = new Matrix(new double[][] {
            new double[] {3,2},
            new double[] {1,-10},
            new double[] {9,-1}
        });
        Matrix E = new Matrix(new double[][] {
            new double[] {-10,10,0},
            new double[] {1,2,10},
            new double[] {30,1,-10}
        });
        [Fact]
        public void A_and_B()
        {
            Matrix result = new Matrix(new double[][] {
            new double[] {130,130},
            new double[] {40,40}
        });
            TestMultiMatrix(A, B, result);
        }
        [Fact]
        public void C_and_D()
        {
            Matrix result = new Matrix(new double[][] {
            new double[] {11,-14},
            new double[] {95,-28}
        });
            TestMultiMatrix(C, D, result);
        }
        [Fact]
        public void D_and_A()
        {
            Matrix result = new Matrix(new double[][] {
            new double[] {11,36},
            new double[] {-7,-20},
            new double[] {26,87}
        });
            TestMultiMatrix(D, A, result);
        }
        [Fact]
        public void C_and_E()
        {
            Matrix result = new Matrix(new double[][] {
            new double[] {-28,34,20},
            new double[] {292,24,-80}
        });
            TestMultiMatrix(C, E, result);
        }
        void TestMultiMatrix(Matrix A, Matrix B, Matrix TestMatrix)
        {
            if (A * B != TestMatrix) throw new Exception("Error in Multiplication. Result is " + A + B);
        }
    }


}
