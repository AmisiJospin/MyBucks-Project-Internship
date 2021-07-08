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
    public partial class AddEmployeeMainPage : UserControl
    {
        public AddEmployeeMainPage()
        {
            InitializeComponent();
            DataManagement.ConnectDB();
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, profile.Width, profile.Height);
            profile.Region = new Region(path);
            Filterextensions();
        }

        List<String> list = new List<string>();
        public void Filterextensions()
        {
            DataManagement.connection.Open();
            foreach (var item in DataManagement.GetAllExtensions())
            {
                ExtensionCombo.Items.Add(item.Extension);
                DepartmentCombo.Items.Add(item.Location);
            }
            DataManagement.connection.Dispose();
            DataManagement.connection.Close();
        }
        private void namebox_Enter(object sender, EventArgs e)
        {
            if(namebox.Text =="Full Names")
            {
                namebox.Text = "";
            }
        }

        private void namebox_Leave(object sender, EventArgs e)
        {
            if (namebox.Text == "")
            {
                namebox.Text = "Full Names";
            }
        }

        private void phonenumber_Enter(object sender, EventArgs e)
        {
            if (phonenumber.Text == "Phone Number")
            {
                phonenumber.Text = "";
            }
        }

        private void phonenumber_Leave(object sender, EventArgs e)
        {
            if (phonenumber.Text == "")
            {
                phonenumber.Text = "Phone Number";
            }
        }
        

        private void Role_Enter(object sender, EventArgs e)
        {
            if (Role.Text == "Role In Department")
            {
                Role.Text = "";
            }
        }

        private void Role_Leave(object sender, EventArgs e)
        {

            if (Role.Text == "")
            {
                Role.Text = "Role In Department";
            }
        }

        private void SaveData_Click(object sender, EventArgs e)
        {
            DataManagement.connection.Open();

            MessageBox.Show(DataManagement.AddEmployee(namebox.Text, gender, ExtensionCombo.Text, phonenumber.Text, DepartmentCombo.Text, Role.Text, DataManagement.ImageToBase64(profile.Image, System.Drawing.Imaging.ImageFormat.Png)));
            DataManagement.connection.Dispose();
            DataManagement.connection.Close();
        }
        string gender;

        private void malegender_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void Femalegender_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }
       
        private void profile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                profile.Image = new Bitmap(open.FileName);
            }

        }
    }
}
