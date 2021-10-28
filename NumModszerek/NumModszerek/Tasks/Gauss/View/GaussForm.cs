using NumModszerek.Tasks.Gauss.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NumModszerek.Tasks.Gauss.View
{
    public partial class GaussForm : Form
    {
        #region Constructor
        public GaussForm()
        {
            InitializeComponent();
            buttonGenerate.MouseDown += generateMatrix;            
        }
        #endregion


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
            GaussModell model = new GaussModell(n);
            
            model.solve();
            foreach (var item in model.resultVector)
            {
                Console.WriteLine(item.ToString());
            };
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n+1; j++)
                {
                    Button b = new Button();
                    b.Width = panel1.Width / (n+1);
                    b.Height = b.Width;
                    b.Left = j * b.Width;
                    b.Top = i * b.Height;
                    if(j < n)
                    {
                        b.Text = model.matrix[i, j].ToString();
                    }
                    else
                    {
                        b.Text = model.bVector[i].ToString();
                    }                    
                    panel1.Controls.Add(b);
                }                
            }
        }
    }
}
