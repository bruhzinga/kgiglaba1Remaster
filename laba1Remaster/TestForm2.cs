using Laba1Remastered;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba1Remaster
{
    public partial class TestForm2 : Form
    {
        public TestForm2()
        {
            InitializeComponent();
        }

        private void TestForm2_Load(object sender, EventArgs e)
        {
            var V1 = new CMatrix(3, 1);
            var V2 = new CMatrix(3, 1);
            MatrixControler.InitializeMatrix(V1);
            MatrixControler.InitializeMatrix(V2);

            richTextBox3.Text = V1.ShowMatrix();
            richTextBox4.Text = V2.ShowMatrix();

            var scal_multp = MatrixControler.ScalarMult(V1, V2);
            richTextBox1.Text = scal_multp.ToString();

            var vect_miltp = MatrixControler.VectorMult(V1, V2);
            richTextBox2.Text = vect_miltp.ShowMatrix();

            var mod = MatrixControler.ModVec(V1);
            richTextBox5.Text = mod.ToString();

            var cos = MatrixControler.CosV1V2(V1, V2);
            richTextBox6.Text = cos.ToString();

            var Coords = MatrixControler.SphereToCart(V1);
            richTextBox7.Text = Coords.ShowMatrix();
        }
    }
}