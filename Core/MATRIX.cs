using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    public class Matrix
    {
        private double[][] _matrix;
        #region Basic
        public Matrix(int rows, int cols)
        {
            _matrix = new double[rows][];

            for (var i = 0; i < rows; i++)
            {
                _matrix[i] = new double[cols];
            }
        }
        public Matrix(double[] tab)
        {
            _matrix = new double[tab.Length][];
            
            for (int i=0;i<tab.Length; i++)
            {
                _matrix[i] = new double[] { tab[i] };
                
            }
            
        }
        public Matrix(double[][] tab)
        {
            _matrix = tab;
        }
        public double[][] Value => _matrix;
        private static double[][] CreateJagged(int rows, int cols)
        {
            var jagged = new double[rows][];

            for (var i = 0; i < rows; i++)
            {
                jagged[i] = new double[cols];
            }

            return jagged;
        }
        #endregion
        #region Mathoperators
        public static Matrix operator +(Matrix a,Matrix b)
        {
            if (a.Value.Length != b.Value.Length || a.Value[0].Length != b.Value[0].Length) throw new Exception("Matrix \"A\" and Matrix \"B\" is not the same size");
            var newMatrix = CreateJagged(a.Value.Length,a.Value[0].Length);
            for (int row = 0; row < a.Value.Length; row++)
            {
                for (int cols = 0; cols < a.Value[0].Length; cols++)
                {
                    newMatrix[row][cols] = a.Value[row][cols] + b.Value[row][cols];
                }
            }
            return new Matrix(newMatrix);
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.Value.Length != b.Value.Length || a.Value[0].Length != b.Value[0].Length) throw new Exception("Matrix \"A\" and Matrix \"B\" is not the same size");
            var newMatrix = CreateJagged(a.Value.Length, a.Value[0].Length);
            for (int row = 0; row < a.Value.Length; row++)
            {
                for (int cols = 0; cols < a.Value[0].Length; cols++)
                {
                    newMatrix[row][cols] = a.Value[row][cols] - b.Value[row][cols];
                }
            }
            return new Matrix(newMatrix);
        }
        public static Matrix operator -(double a, Matrix m)
        {
            for (var x = 0; x < m.Value.Length; x++)
            {
                for (var y = 0; y < m.Value[x].Length; y++)
                {
                    m.Value[x][y] = a - m.Value[x][y];
                }
            }

            return m;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            var newMatrix = CreateJagged(a.Value.Length, b.Value[0].Length);

            for (int row = 0; row < a.Value.Length; row++)
            {
                for (int cols = 0; cols < b.Value[0].Length; cols++)
                {
                    double value=0;
                    for (int x = 0; x < b.Value.Length; x++)
                    {
                        value += a.Value[row][x] * b.Value[x][cols];
                       // Console.WriteLine(row + ":" + cols + "  " + x + " = " + value);
                    }
                    newMatrix[row][cols] = value;
                    
                }
            }


            return new Matrix(newMatrix);
        }
        public static Matrix operator *(Matrix a, double b)
        {
            

            for (int row = 0; row < a.Value.Length; row++)
            {
                for (int cols = 0; cols < a.Value[0].Length; cols++)
                { 
                    a.Value[row][cols] *= b;

                }
            }


            return a;
        }
        public static Matrix operator *(double b, Matrix a)
        {
            return a*b;
        }
        public static Matrix operator /(Matrix a, double b)
        {
            
            for (int row = 0; row < a.Value.Length; row++)
            {
                for (int cols = 0; cols < a.Value[0].Length; cols++)
                {
                    a.Value[row][cols] /= b;

                }
            }


            return a;
        }
        
        public double determinant()
        {
            if (_matrix.Length == 1 && _matrix[0].Length == 1)
            {
                return _matrix[0][0];
            }


            if (_matrix.Length==2&&_matrix[0].Length==2)
            {
                return _matrix[0][0] * _matrix[1][1] - _matrix[0][1] * _matrix[1][0];
            }
            if (_matrix.Length == 3 && _matrix[0].Length == 3)
            {
                double step1 = _matrix[0][0] * _matrix[1][1] * _matrix[2][2] + _matrix[0][1] * _matrix[1][2] * _matrix[2][0] + _matrix[0][2] * _matrix[1][0] * _matrix[2][1];
                double step2 = _matrix[2][0] * _matrix[1][1] * _matrix[0][2] + _matrix[2][1] * _matrix[1][2] * _matrix[0][0]+ _matrix[2][2] * _matrix[1][0] * _matrix[0][1];
                return step1-step2;
            }
            if (_matrix.Length==_matrix[0].Length)
            {
                double det=0;
                for(int i =0; i < _matrix[0].Length;i++)
                {
                    Matrix newM = minor(new int[] { 0 }, new int[] { i });
                    det += ((i % 2) == 1 ? -1 : 1) * _matrix[0][i] * newM.determinant();
                  
                }
                return det;
            
            }
                throw new Exception("I can't calculating determinat from matrix " + _matrix.Length + "x" + _matrix[0].Length);

        }
        public double trace()
        {
            if (_matrix.Length != _matrix[0].Length) throw new Exception("this matrix is not square ");
            double tr = 0;
            for(int i=0;i<_matrix.Length;i++)
            {
                tr += _matrix[i][i];
            }
            return tr;
        }
        public Matrix minor(int[] cutRows,int[] cutCols)
        {
            int rows = _matrix.Length - cutRows.Length;
            int cols = _matrix[0].Length - cutCols.Length;
            double[][] matrix = CreateJagged(rows, cols);
            int tempRows=0,tempCols=0;
            for(int i=0;i < _matrix.Length; i++)
            {
                if(!isInTab(cutRows,i))
                {
                  
                    for (int j = 0; j < _matrix[0].Length; j++)
                    {
                      
                        if (!isInTab(cutCols, j))
                        {
                            
                            matrix[tempRows][tempCols] = _matrix[i][j];
                            tempCols++;
                        }
                    }
                    tempRows++;
                    tempCols = 0;
                }
            }
            return new Matrix(matrix);
        }
        public Matrix complement()
        {
            if (_matrix.Length != _matrix[0].Length) throw new Exception("this matrix is not square ");
            var newMatrix = CreateJagged(_matrix.Length, _matrix[0].Length);
            for (int row = 0; row < _matrix.Length; row++)
            {
                for (int cols = 0; cols < _matrix[0].Length; cols++)
                {
                    newMatrix[row][cols] = OperationComplement(row, cols);
                }
            }
            return new Matrix(newMatrix);
        }
        public Matrix transpose()
        {
            var newMatrix = CreateJagged(_matrix[0].Length, _matrix.Length);
            for (int row = 0; row < _matrix[0].Length; row++)
            {
                for (int cols = 0; cols < _matrix.Length; cols++)
                {
                    newMatrix[row][cols] = _matrix[cols][row];
                }
            }
            return new Matrix(newMatrix);
        }
        public Matrix inverse()
        {
            if (_matrix.Length != _matrix[0].Length) throw new Exception("this matrix is not square ");

            double detA =this.determinant();
            if(detA == 0) throw new Exception("Determinant mustn't be 0");
            Matrix adjugate = (complement()).transpose();

            return adjugate/detA;//adjugate/detA
        }
        public void Initialize(Func<double> elementInitializer)
        {
            for (var x = 0; x < _matrix.Length; x++)
            {
                for (var y = 0; y < _matrix[x].Length; y++)
                {
                    _matrix[x][y] = elementInitializer();
                }
            }
        }
        #endregion
        #region EqualeOPerators
        public static bool operator ==(Matrix a, Matrix b)
        {
            double[][] atab = a.Value;
            double[][] btab = b.Value;
            if (atab.Length != btab.Length || atab[0].Length != btab[0].Length) throw new Exception("Matrix \"A\" and Matrix \"B\" is not the same size");

            for (int row = 0; row < atab.Length; row++)
            {
                for (int cols = 0; cols < atab[0].Length; cols++)
                {
                    if (atab[row][cols] != btab[row][cols]) return false;
                }
            }
            return true;
        }
        public static bool operator !=(Matrix a, Matrix b) => !(a == b);
        #endregion
        double OperationComplement(int row,int col)
        { 
            Matrix newM = minor(new int[] { row }, new int[] { col }); 
            return ((row + col + 2) % 2 == 1 ? -1 : 1) * newM.determinant();
        }
        public string ToString()
        {
            string MatrixInString = "";
            
            for (int row = 0; row < _matrix.Length; row++)
            {
                MatrixInString += "[";
                for (int cols = 0; cols < _matrix[0].Length; cols++)
                {
                    MatrixInString += (cols != 0 ? "," : "")+ _matrix[row][cols].ToString();
                }
                MatrixInString += "]\n";
            }
            return MatrixInString;
        }
        public bool isInTab(int[] tab,int findingElement)
        {
            foreach(int el in tab)
            {
                if (el == findingElement) return true;
            }
            return false;
        }
    }
}
