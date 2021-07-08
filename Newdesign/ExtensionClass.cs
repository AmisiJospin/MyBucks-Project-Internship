using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newdesign
{
   public class ExtensionClass
    {

        public string  Extension,  Location;
        public static int ID;

        public ExtensionClass()
        {

        }

        public ExtensionClass(string extension, string location)
        {
           
            Extension = extension;
            Location = location;
        }

        public ExtensionClass(int id,string extension, string location)
        {
            ID = id;
            Extension = extension;
            Location = location;
        }
    }
}
