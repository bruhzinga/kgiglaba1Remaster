using System;
using System.Drawing.Drawing2D;
using System.Linq;

namespace Laba1Remastered
{
    public class CMatrix
    {
        public int NumberOfRows { get; private set; }
        public int NumberOfColumns { get; private set; }
        public double[,] Content { get; private set; }

        public double this[int raw, int column]
        {
            get
            {
                if (raw < 0 || column < 0 || raw > NumberOfRows || column > NumberOfColumns)
                    throw new Exception("Ошибка индексатора");
                return Content[raw, column];
            }
            set => Content[raw, column] = value;
        }

        public double this[int raw]
        {
            get
            {
                if (raw < 0 || raw > NumberOfRows)
                    throw new Exception("Ошибка индексатора");
                return Content[raw, 0];
            }
            set => Content[raw, 0] = value;
        }

        public CMatrix()
        {
            NumberOfRows = 1;
            NumberOfColumns = 1;
            Content = new double[NumberOfRows, NumberOfColumns];
        }

        public CMatrix(int numberOfRows, int numberofColumns)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberofColumns;

            Content = new double[NumberOfRows, NumberOfColumns];
            //TODO первым столбцы или колонны?
        }

        public CMatrix(int numberOfRows)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = 1;

            Content = new double[NumberOfRows, NumberOfColumns];
        }

        public CMatrix(CMatrix matrix)
        {
            NumberOfColumns = matrix.NumberOfColumns;
            NumberOfRows = matrix.NumberOfRows;

            Content = new double[NumberOfRows, NumberOfColumns];
            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfColumns; j++)
                {
                    Content[i, j] = matrix.Content[i, j];
                }
            }
            Content = matrix.Content;
        }

        //TODO переопределение оператора ()

        public string ShowMatrix()
        {
            var output = "\n";
            for (var i = 0; i < NumberOfRows; i++)
            {
                for (var i1 = 0; i1 < NumberOfColumns; i1++)
                {
                    output += (Content[i, i1] + " ");
                }
                output += "\n";
            }
            return output;
        }

        #region Переопределённые операторы

        public static CMatrix operator +(CMatrix resultMatrix, CMatrix summandMatrix)
        {
            if (resultMatrix.NumberOfColumns != summandMatrix.NumberOfColumns || resultMatrix.NumberOfRows != summandMatrix.NumberOfRows)
                throw new Exception("Матрицы разноразмерные");

            for (int i = 0; i < resultMatrix.NumberOfRows; i++)
            {
                for (int j = 0; j < resultMatrix.NumberOfColumns; j++)
                {
                    resultMatrix.Content[i, j] += summandMatrix.Content[i, j];
                }
            }

            return resultMatrix;
        }

        public static CMatrix operator -(CMatrix resultMatrix, CMatrix summandMatrix)
        {
            if (resultMatrix.NumberOfColumns != summandMatrix.NumberOfColumns || resultMatrix.NumberOfRows != summandMatrix.NumberOfRows)
                throw new Exception("Матрицы разноразмерные");

            for (int i = 0; i < resultMatrix.NumberOfRows; i++)
            {
                for (int j = 0; j < resultMatrix.NumberOfColumns; j++)
                {
                    resultMatrix.Content[i, j] -= summandMatrix.Content[i, j];
                }
            }

            return resultMatrix;
        }

        public static CMatrix operator -(CMatrix matrix)
        {
            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfColumns; j++)
                {
                    matrix.Content[i, j] = -matrix.Content[i, j];
                }
            }
            return matrix;
        }

        public static CMatrix operator *(CMatrix firstMultiplier, CMatrix secondMultiplier)
        {
            /*if (firstMultiplier.NumberOfRows != firstMultiplier.NumberOfColumns)
                throw new Exception("Матрицы не подходят для умножения ");

            var resultMatrix = new CMatrix(firstMultiplier.NumberOfRows, secondMultiplier.NumberOfColumns);

            double sum;
            for (var i = 0; i < firstMultiplier.NumberOfRows; i++)
            {
                for (var i1 = 0; i1 < secondMultiplier.NumberOfColumns; i1++)
                {
                    sum = 0;

                    for (var i2 = 0; i2 < firstMultiplier.NumberOfColumns; i2++)
                    {
                        sum += firstMultiplier[i, i2] * secondMultiplier[i2, i1];
                        secondMultiplier[i, i1] = sum;
                    }
                }
            }*/

            /* return resultMatrix;*/

            var matrix1Rows = firstMultiplier.Content.GetLength(0);
            var matrix1Cols = firstMultiplier.Content.GetLength(1);
            var matrix2Rows = secondMultiplier.Content.GetLength(0);
            var matrix2Cols = secondMultiplier.Content.GetLength(1);

            // checking if product is defined
            if (matrix1Cols != matrix2Rows)
                throw new InvalidOperationException
                  ("Product is undefined. n columns of first matrix must equal to n rows of second matrix");

            // creating the final product matrix
            double[,] product = new double[matrix1Rows, matrix2Cols];

            // looping through matrix 1 rows
            for (int matrix1_row = 0; matrix1_row < matrix1Rows; matrix1_row++)
            {
                // for each matrix 1 row, loop through matrix 2 columns
                for (int matrix2_col = 0; matrix2_col < matrix2Cols; matrix2_col++)
                {
                    // loop through matrix 1 columns to calculate the dot product
                    for (int matrix1_col = 0; matrix1_col < matrix1Cols; matrix1_col++)
                    {
                        product[matrix1_row, matrix2_col] +=
                          firstMultiplier.Content[matrix1_row, matrix1_col] *
                          secondMultiplier.Content[matrix1_col, matrix2_col];
                    }
                }
            }
            var prod = new CMatrix(matrix1Rows, matrix2Cols);
            prod.Content = product;
            return prod;
        }

        #endregion Переопределённые операторы

        public void Clone(CMatrix matrix)
        {
            NumberOfColumns = matrix.NumberOfColumns;
            NumberOfRows = matrix.NumberOfRows;

            Content = new double[NumberOfRows, NumberOfColumns];
            for (int i = 0; i < matrix.NumberOfRows; i++)
            {
                for (int j = 0; j < matrix.NumberOfColumns; j++)
                {
                    Content[i, j] = matrix.Content[i, j];
                }
            }
            Content = matrix.Content;
        }

        public CMatrix Transpose()
        {
            var temp = new double[NumberOfColumns, NumberOfRows];

            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    temp[j, i] = Content[i, j];
                }
            }

            var resultMatrix = new CMatrix(NumberOfColumns, NumberOfRows)
            {
                Content = temp
            };
            return resultMatrix;
        }

        public CMatrix GetRow(int rawNumber)
        {
            if (rawNumber > NumberOfRows || rawNumber < 1)
                throw new Exception("Некоректное число столбцов");

            CMatrix raw = new CMatrix(1, NumberOfColumns);

            for (int i = 0; i < NumberOfColumns; i++)
            {
                raw.Content[0, i] = Content[rawNumber - 1, i];
            }

            return raw;
        }

        public CMatrix GetRow(int rawNumber, int firstRawElement, int lastRawElement)
        {
            if (rawNumber < 0 || firstRawElement < 0 || lastRawElement < 0)
                throw new Exception("Ошибка в параметрах");
            if (firstRawElement - 1 > NumberOfColumns || lastRawElement - 1 > NumberOfColumns)
                throw new Exception("Ошибка в параметрах");

            int lenghtOfRaw = firstRawElement + lastRawElement - 2;
            var Column = new CMatrix(1, lenghtOfRaw);

            for (int i = firstRawElement - 1, j = 0; i <= lastRawElement; i++, j++)
            {
                Column.Content[0, j] = Content[rawNumber - 1, i];
            }

            return Column;
        }

        public CMatrix GetColumn(int columnNumber)
        {
            if (columnNumber > NumberOfColumns || columnNumber < 1)
                throw new Exception("Некоректное число столбцов");

            CMatrix raw = new CMatrix(NumberOfColumns, 1);

            for (int i = 0; i < NumberOfRows; i++)
            {
                raw.Content[i, 0] = Content[i, columnNumber - 1];
            }

            return raw;
        }

        public CMatrix GetColumn(int columnNumber, int firstColumnElement, int lastColumnElement)
        {
            //TODO Проверки странны плюс надо их дописать
            if (columnNumber < 0 || firstColumnElement < 0 || lastColumnElement < 0)
                throw new Exception("Ошибка в параметрах");
            if (firstColumnElement - 1 > NumberOfRows || lastColumnElement - 1 > NumberOfRows)
                throw new Exception("Ошибка в параметрах");

            int lengthOfColumn = firstColumnElement + lastColumnElement - 2;
            var Column = new CMatrix(lengthOfColumn, 1);

            for (int i = firstColumnElement - 1, j = 0; i <= lastColumnElement; i++, j++)
            {
                Column.Content[j, 0] = Content[i, columnNumber - 1];
            }

            return Column;
        }

        public void RedimMatrix(int newNumberOfRows, int newNumberOfColumns)
        {
            this.Content = new double[newNumberOfRows, newNumberOfColumns];
            NumberOfColumns = newNumberOfColumns;
            NumberOfRows = newNumberOfRows;
        }

        public void RedimMatrix(int newNumberOfRows)
        {
            this.Content = new double[newNumberOfRows, 1];
            NumberOfColumns = 1;
            NumberOfRows = newNumberOfRows;
        }

        public void RedimData(int newNumberOfRows, int newNumberOfColumns)
        {
            var newContent = new double[newNumberOfRows, newNumberOfColumns];

            for (var i = 0; i < NumberOfRows && i < newNumberOfRows; i++)
            {
                for (var i1 = 0; i1 < NumberOfColumns && i1 < newNumberOfColumns; i1++)
                {
                    newContent[i, i1] = this.Content[i, i1];
                }
            }
            this.Content = newContent;
            NumberOfColumns = newNumberOfColumns;
            NumberOfRows = newNumberOfRows;
        }

        public void RedimData(int newNumberOfRows)
        {
            var newContent = new double[newNumberOfRows, 1];

            for (var i = 0; i < NumberOfRows && i < newNumberOfRows; i++)
            {
                for (var i1 = 0; i1 < NumberOfColumns && i1 < 1; i1++)
                {
                    newContent[i, i1] = this.Content[i, i1];
                }
            }
            this.Content = newContent;
            NumberOfColumns = 1;
            NumberOfRows = newNumberOfRows;
        }

        public double FindMaxElement()
        {
            return Content.Cast<double>().Max();
        }

        public double FindMinElement()
        {
            return Content.Cast<double>().Min();
        }
    }
}