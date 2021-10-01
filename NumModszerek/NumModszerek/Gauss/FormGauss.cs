using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NumModszerek.Gauss
{
    public partial class FormGauss : Form
    {
        public FormGauss()
        {
            InitializeComponent();
            buttonGenerate.MouseDown += generateMatrix;
            
        }

        private void generateMatrix(object sender, EventArgs e)
        {

            panel1.Controls.Clear();
            int n;
            try
            {
                n = int.Parse(textBox1.Text);
            }
            catch (Exception)
            {
                n = 3;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Button b = new Button();
                    b.Width = panel1.Width / n;
                    b.Height = b.Width;
                    b.Left = i * b.Width;
                    b.Top = j * b.Height;
                    
                    panel1.Controls.Add(b);
                }
            }
        }
    }
}
