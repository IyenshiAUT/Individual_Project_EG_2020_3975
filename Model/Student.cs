using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace StudentManagementSystem.Model
{
    public class Student
    {
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BitmapImage Image { get; set; }
        public DateOnly DateofBirth { get; set; }
        public double GPA { get; set; }

        public Student(string studentID, string firstName, string lastName, BitmapImage image, DateOnly dateofBirth, double gPA)
        {
            StudentID = "EG/2020/" + studentID;
            FirstName = firstName;
            LastName = lastName;
            Image = image;
            DateofBirth = dateofBirth;
            GPA = gPA;
        }
        public Student() { 
        }
    }
}
