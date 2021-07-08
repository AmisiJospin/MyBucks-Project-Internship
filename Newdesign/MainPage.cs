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
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, profilepic.Width, profilepic.Height);
            profilepic.Region = new Region(path);
            DataManagement.ConnectDB();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Search Employee...")
            {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Search Employee...";
            }

        }

        private void searchBt_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            DataManagement.connection.Open();
            foreach (var item in DataManagement.GetAllEmployees())
            {
                if (item.Name.ToLower().Equals(textBox1.Text.ToLower()))
                {
                    profilepic.Image =DataManagement.Base64ToImage(item.Profileimages);
                    Extension.Text = item.Extension;
                    employeename.Text = item.Name;
                    Gender.Text = item.Gender;
                    Phone.Text = item.PhoneNumber;
                    department.Text = item.Location;
                    Role.Text = item.Role;
                   
                    break;

                }
               
            }
            textBox1.Text = "";
            DataManagement.connection.Dispose();
            DataManagement.connection.Close();
        }
    }
}
