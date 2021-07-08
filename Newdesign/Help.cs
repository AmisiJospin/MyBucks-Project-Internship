using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Newdesign
{
    public partial class Help : UserControl
    {
        public Help()
        {
            InitializeComponent();
            
            label3.Text = "Home: In This option You are Able to Search Any Employee Who is registered in the database";
            label4.Text = "This Option is used to Add The Department name and extension number used for communication";
            label5.Text = "To Add A new Employee This option will help.";
        }

    }
}
