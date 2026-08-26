using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newdesign
{
    public class RegisterProperties
    {
        public string Name, Gender, Extension, PhoneNumber, Location, Role,Profileimages;
        public static int ID;

        public RegisterProperties()
        {

        }

        // This constructor will get the values of the registration page
        public RegisterProperties(string name, string gender, string extension, string phoneNumber, string location, string role, string profileImages)
        {
            Name = name;
            Gender = gender;
            Extension = extension;
            PhoneNumber = phoneNumber;
            Location = location;
        }

        //Getting the values from the form and add it to the database
        public RegisterProperties(int id, string name, string gender, string extension, string phoneNumber, string location, string role, string profileImages)
        {
            ID = id;
            Name = name;
            Gender = gender;
            Extension = extension;
            PhoneNumber = phoneNumber;
            Location = location;
            Role = role;
            Profileimages = profileImages;

        }
    }
}
