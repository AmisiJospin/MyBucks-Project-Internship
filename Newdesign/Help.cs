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
            
            label3.Text = "Home: In this option, you can search for any employee who is registered in the database";
            label4.Text = "This option is used to add the department name and extension number used for communication";
            label5.Text = "To add a new employee, this option will help. You need to have his information to add.";
        }
        
        public static Name(){
            float number = 5.8;
            number = number.int();
        }
    }
}
