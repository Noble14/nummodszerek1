using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NumModszerek.Tasks.Gauss.View;

namespace NumModszerek.View
{
    public partial class MainMenuForm : Form
    {

        #region Constructor
        public MainMenuForm()
        {
            InitializeComponent();

            button1.Text = resource.menuMachineNumbers;
            button2.Text = resource.menuGauss;

            button2.MouseDown += startGaussForm;
        }
        #endregion

        private void startGaussForm(object sender, EventArgs e)
        {
            GaussForm f = new GaussForm();
            f.Show();
        }
    }
}
