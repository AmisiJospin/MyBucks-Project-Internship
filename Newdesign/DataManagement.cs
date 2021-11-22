using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newdesign
{
    public class DataManagement
    {
        public static List<RegisterProperties> ArrayEmployee = new List<RegisterProperties>();
        public static List<ExtensionClass> ArrayExtension = new List<ExtensionClass>();
        public static SqlConnection connection;
        public static SqlCommand command;
        public static SqlDataReader read;

        // CONNECTION OF DATABASE AND THE APPLICATION
        public static void ConnectDB()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=NFBDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        //INSERT DATA INTO THE TABLE EMPLOYEES
        public static string AddEmployee(string name, string gender, string extension, string phone, string location,string role, string profile)
        {
            if (connection == null)
            {
                connection.Open();
            }

            command = new SqlCommand("INSERT INTO Employee (Name, Gender, Extension, PhoneNumber, Location,Role,Profile) VALUES ('" + name + "', '" + gender + "', '" + extension + "', '" + phone + "', '" + location + "', '" + role + "', '" + profile + "')", connection);

            if (command.ExecuteNonQuery() == 1)
            {
                command.Dispose();
                connection.Close();
                return "Employee saved successful";
            }
            else
            {
                command.Dispose();
                connection.Close();
                return "Saving Failed";

            }

        }
    
        // INSERT A NEW EXTENSION and LOCATION
        public static string AddExtensions(string extension, string location)
        {
            if (connection == null)
            {
                connection.Open();
            }

            command = new SqlCommand("INSERT INTO Extensions (Extension,Location) VALUES ('" + extension + "', '" + location + "')", connection);

            if (command.ExecuteNonQuery() == 1)
            {
                command.Dispose();
                connection.Close();
                return "Extension saved successful";
            }
            else
            {
                command.Dispose();
                connection.Close();
                return "Saving Failed";

            }

        }

        // SELECT ALL FROM THE TABLE EMPLOYEES
        public static List<RegisterProperties> GetAllEmployees()
        {
            if (connection == null)
            {
                connection.Open();
            }

            command = new SqlCommand("SELECT * FROM Employee", connection);
            read = command.ExecuteReader();
            while (read.Read())
            {
                RegisterProperties register = new RegisterProperties(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3), read.GetString(4), read.GetString(5),read.GetString(6),read.GetString(7));
                ArrayEmployee.Add(register);
            }
            return ArrayEmployee;
        }

        public static List<ExtensionClass> GetAllExtensions()
        {
            if (connection == null)
            {
                connection.Open();
            }

            command = new SqlCommand("SELECT * FROM Extensions", connection);
            read = command.ExecuteReader();
            while (read.Read())
            {
                ExtensionClass register = new ExtensionClass(read.GetInt32(0), read.GetString(1), read.GetString(2));
                ArrayExtension.Add(register);
            }
            return ArrayExtension;
        }

        //UPDATE AN EMPLOYEE
        public static string UpdateEmployee(int id, string name, string gender, string extension, string phone, string location, string role, string profileimages)
        {
            if (connection == null)
            {
                connection.Open();

            }
            command = new SqlCommand("UPDATE Employee SET Name = '" + name + "', Gender=" + "'" + gender + "', Extension='" + extension + "', PhoneNumber='" + phone + "', Location='" + location + "', Role='" + role + "', Profile='" + profileimages + "' WHERE ID=" + id, connection);

            if (command.ExecuteNonQuery() == 1)
            {
                command.Dispose();
                connection.Close();
                return "Successful updated";
            }
            else
            {
                command.Dispose();
                connection.Close();
                return "Update Failed";
            }
        }

        //DELETE EMPLOYEE

        public static string DeleteUser(int Id)
        {
            if (connection == null)
            {
                connection.Open();

            }

            command = new SqlCommand("DELETE Employee WHERE ID=" + Id, connection);


            if (command.ExecuteNonQuery() == 1)
            {
                command.Dispose();
                connection.Close();
                return "Successful deleted";
            }
            else
            {
                command.Dispose();
                connection.Close();
                return "Failed";
            }
        }

        public static string ImageToBase64(Image image,
          System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public static Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
        
        // ADD A NEW USER
        
        public static AddingUsers(){
            String name = "";
            if(name.equals("Jospin")){
                Print("Well done" + name);
            }
        }


    }
}
