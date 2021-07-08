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

        public RegisterProperties(string name, string gender, string extension, string phoneNumber, string location, string role, string profileImages)
        {
            Name = name;
            Gender = gender;
            Extension = extension;
            PhoneNumber = phoneNumber;
            Location = location;
        }

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
