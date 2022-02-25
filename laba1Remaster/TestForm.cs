using laba1Remaster;
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
        public CMatrix Matrix1;
        public CMatrix Matrix2;
        public CMatrix V1;
        public CMatrix V2;

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            Matrix1 = new CMatrix(3, 3);
            MatrixControler.InitializeMatrix(Matrix1);
            Matrix2 = new CMatrix(3, 3);
            MatrixControler.InitializeMatrix(Matrix2);
            V1 = new CMatrix(3, 1);
            MatrixControler.InitializeMatrix(V1);
            V2 = new CMatrix(3, 1);
            MatrixControler.InitializeMatrix(V2);
        }

        private void матрицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            matrix1.Text = Matrix1.ShowMatrix();

            matrix2.Text = Matrix2.ShowMatrix();

            richTextBox3.Text = V1.ShowMatrix();
            richTextBox4.Text = V2.ShowMatrix();

            var sum_result = Matrix1 + Matrix2;
            richTextBox5.Text = sum_result.ShowMatrix();
            var mult_result = Matrix1 * Matrix2;
            richTextBox6.Text = mult_result.ShowMatrix();
            var mult2_result = Matrix1 * V1;
            richTextBox7.Text = mult2_result.ShowMatrix();
            var mult3_result = V1.Transpose() * V2;
            richTextBox8.Text = mult3_result.ShowMatrix();
            var mult4_result = V1.Transpose() * Matrix1 * V2;
            richTextBox9.Text = mult4_result.ShowMatrix();
        }

        private void функцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TestForm2();
            form.ShowDialog();
        }
    }
}