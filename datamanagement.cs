using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Appfactory
{
    class DataManagement
    {
        public static Appfactory[] students;

        public static string path = @"DataManagementSpace\Database";

        public static Object[] images = { Properties.Resources.AppFactoryi, Properties.Resources.IMG_20170724_WA0004, Properties.Resources.Students_512, 
                                           Properties.Resources.admin, Properties.Resources.admin1
                                        };

        // Activation of and initialization of array
        public static void studentsActivator() {
            students = new Appfactory[20];

            for (byte i = 0; i < students.Length; i++)
            {
                if (students[i] == null)
                {
                    students[i] = new Appfactory();
                }
            }
        }

        // Add 5 students in array without passing from the form of adding
        public static void AddFiveStudents()
        {

            string[] names = { "Thierry Irakoza", "Salama Africa", "Kibonge John", "Jospin Kambale", "Johnson Kiza" };
            byte[] ages = { 20, 70, 43, 34, 12 };
            char[] genders = { 'M', 'F', 'M', 'F', 'M' };
            string[] location = { "Likuni", "Kawale", "Blantyre", "Zomba", "Lisungwe" };
            string[] phoneNumber = { "0992129078", "0885042078", "0997522157", "0887838609", "0997560309" };
            string[] laptopNumber = { "35423", "35001", "35211", "35120", "35005" };
            string[] studentNumber = { "af21", "af15", "af4", "af10", "af7" };
            string[] description = { "HP Elite Book", "ASUS new Version", "HP Elite Book", "ASUS new Version", "HP Elite Book" };
            string[] serialNum = { "5GC893J", "5GC893J", "5GC893J", "5GC893J", "5GC893J" };
            string[] macAddress = { "F3434433df", "F3434433df", "F3434433df", "F3434433df", "F3434433df" };
        
            for (int j = 0; j < names.Length; j++)
            {
                students[j] = new Appfactory();

                students[j].Name = names[j];
                students[j].Age = ages[j];
                students[j].Gender = genders[j];
                students[j].Location = location[j];
                students[j].PhoneNumber = phoneNumber[j];
                students[j].ImeiNumber = laptopNumber[j];
                students[j].StudentNumber = studentNumber[j];
                students[j].Description = description[j];
                students[j].SerialNum = serialNum[j];
                students[j].MacAddress = macAddress[j];
            }

        }

        // Adding a new student
        public static void AddNewStudent(string name, byte age, char gender, string location, string phone, string stdNumber, string laptopNum, string descr, string serialNum, string macAdr, string dateOfToday, string timeIn, string timeOut, int images)
        {
            for (int j = 0; j < students.Length; j++)
            {
                if (students[j] != null)
                {
                    if (students[j].Name == null)
                    {
                        if (name.Length > 4 && age > 8 && location.Length >= 2 && (gender.ToString().ToUpper() == "M" || gender.ToString().ToUpper() == "F") && stdNumber.Length > 2 && laptopNum.ToString().Length >= 3 )
                        {
                        students[j].Name = name;
                        students[j].Age = age;
                        students[j].Gender = gender;
                        students[j].Location = location;
                        students[j].PhoneNumber = phone;
                        students[j].StudentNumber = stdNumber;
                        students[j].ImeiNumber = laptopNum;
                        students[j].Description = descr;
                        students[j].SerialNum = serialNum;
                        students[j].MacAddress = macAdr;
                        students[j].DateOfDay = dateOfToday;
                        students[j].TimeIn = timeIn;
                        students[j].TimeOut = timeOut;
                        students[j].Images = images;
                        break;
                        }
                    }
                }
            }
        }

        // Update a student
        public static void Update(string name, byte age, char gender, string location, string phone, string stdNumber, string laptopNum, string descr, string serialNum, string macAdr, string dateOfToday, string timeIn, string timeOut, int images)
        {
            for (int j = 0; j < students.Length; j++)
            {
                if(students[j] != null){
                    if (j == ViewStudent.index) {

                        students[j].Name = name;
                        students[j].Age = age;
                        students[j].Gender = gender;
                        students[j].Location = location;
                        students[j].PhoneNumber = phone;
                        students[j].ImeiNumber = laptopNum;
                        students[j].StudentNumber = stdNumber;
                        students[j].Description = descr;
                        students[j].SerialNum = serialNum;
                        students[j].MacAddress = macAdr;
                         students[j].DateOfDay = dateOfToday;
                        students[j].TimeIn = timeIn;
                        students[j].TimeOut = timeOut;
                        students[j].Images = images;
                        break;
                        
                    }
                }
            }
        }


        // load student in a file 
        public static void LoadStudentInToArrayFromFile() {

            // This is a path of creating a folder of where your list of student will be stored.
            // By adding a backslash can create another folder within your application in debug
            // When you are creating a folder where u don't have access of the admin then u have to specify
            // the security system.


            if (Directory.Exists(path))
            {

            }
            else {
                Directory.CreateDirectory(path);
            }

            if (File.Exists(path + @"\studentManagement.cvs"))
            {
            }
            else {
                StreamWriter createNow = new StreamWriter(path + @"\studentManagement.cvs");
                createNow.Close();
            }

            StreamReader arrayFilter = new StreamReader(path + @"\studentManagement.cvs");

            string line;
            while ((line = arrayFilter.ReadLine()) != null) {
                string[] temp = line.Split(',');
                if (temp.Length >= 5) {
                     AddNewStudent(temp[0], byte.Parse(temp[1]), char.Parse(temp[2]), temp[3], temp[4], temp[5], temp[6], temp[7], temp[8], temp[9], temp[10],temp[11], temp[12], int.Parse(temp[13]));
                }
            }
            arrayFilter.Close();
        }


        // write a student from array to a file
        public static void WriteStudentToFileFromArray() {

            StreamWriter filefilter = new StreamWriter(path + @"\studentManagement.cvs");

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i] != null) {
                    if (students[i].Name != null) {
                        filefilter.WriteLine(students[i].Name + "," + students[i].Age + "," + students[i].Gender + "," + students[i].Location + "," + students[i].PhoneNumber + "," + students[i].StudentNumber + "," + students[i].ImeiNumber + "," + students[i].Description + "," + students[i].SerialNum + "," + students[i].MacAddress + "," + students[i].DateOfDay + "," + students[i].TimeIn + "," + students[i].TimeOut + "," + students[i].Images);
                    }
                }
            }
            filefilter.Close();
        }
    }
}
