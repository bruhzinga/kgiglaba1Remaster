using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1Remastered
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
        }

        private void матрицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var matrix_5X5 = new CMatrix(2, 2);
            MatrixControler.InitializeMatrix(matrix_5X5);
            matrix1.Text = matrix_5X5.ShowMatrix();

            var matrix_5x5_2 = new CMatrix(2, 2);
            MatrixControler.InitializeMatrix(matrix_5x5_2);
            matrix2.Text = matrix_5x5_2.ShowMatrix();

            var sum_result = matrix_5X5 + matrix_5x5_2;
            richTextBox5.Text = sum_result.ShowMatrix();
            var mult_result = matrix_5X5 * matrix_5x5_2;
            richTextBox6.Text = mult_result.ShowMatrix();
        }
    }
}