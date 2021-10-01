using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumModszerek
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();

            button1.Text = resource.menuMachineNumbers;
            button2.Text = resource.menuGauss;
        }

    }
}
