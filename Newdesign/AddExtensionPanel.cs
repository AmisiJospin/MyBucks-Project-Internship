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
    public partial class AddExtensionPanel : UserControl
    {
        public AddExtensionPanel()
        {
            InitializeComponent();
            DataManagement.ConnectDB();
        }

        private void Departmentname_Enter(object sender, EventArgs e)
        {

            if (Departmentname.Text == "Enter Department Name here...")
            {
                Departmentname.Text = "";
            }
        }

        private void Departmentname_Leave(object sender, EventArgs e)
        {
            if (Departmentname.Text == "")
            {
                Departmentname.Text = "Enter Department Name here...";
            }
        }

        private void ExtensionNumber_Enter(object sender, EventArgs e)
        {

            if (ExtensionNumber.Text == "Enter extension number here...")
            {
                ExtensionNumber.Text = "";
            }
        }

        private void ExtensionNumber_Leave(object sender, EventArgs e)
        {

            if (ExtensionNumber.Text == "")
            {
                ExtensionNumber.Text = "Enter extension number here...";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataManagement.connection.Open();
            MessageBox.Show(DataManagement.AddExtensions(ExtensionNumber.Text, Departmentname.Text));
            DataManagement.connection.Dispose();
            DataManagement.connection.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
