using System;
using System.Windows.Forms;

namespace Laba1Remastered
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //тесты конструкторов
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("------------тест конструкторов----------------");
            Console.ResetColor();

            Console.WriteLine();
            var matrix_1X1 = new CMatrix();
            matrix_1X1.ShowMatrix();

            var matrix_5X5 = new CMatrix(5, 5);
            matrix_5X5.ShowMatrix();

            var matrix_5X1 = new CMatrix(5);
            matrix_5X1.ShowMatrix();

            var matrxix_5X1_Copy = new CMatrix(matrix_5X1);
            matrxix_5X1_Copy.ShowMatrix();

            //тесты функций
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------тест функций----------------");
            Console.ResetColor();

            var matrix_1X5 = matrix_5X1.Transpose();
            matrix_1X5.ShowMatrix();

            MatrixControler.InitializeMatrix(matrix_5X5);
            matrix_5X5.ShowMatrix();

            matrix_5X5.GetRow(5).ShowMatrix();
            matrix_5X5.GetColumn(3, 2, 4).ShowMatrix();

            matrix_5X5.RedimData(4, 4);
            matrix_5X5.ShowMatrix();
            matrix_5X5.RedimMatrix(3, 3);
            matrix_5X5.ShowMatrix();
            ApplicationConfiguration.Initialize();
            Application.Run(new TestForm());
        }
    }
}