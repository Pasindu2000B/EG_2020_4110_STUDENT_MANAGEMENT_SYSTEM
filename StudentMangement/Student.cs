using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace StudentMangement
{
    public class Student
    {
        public int Age { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public BitmapImage? Image { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Double GPA { get; set; }



        public Student(string firstName, string lastName, DateTime dateOfBirth, BitmapImage image, double gpa)
        {

            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Image = image;
            GPA = gpa;

        }

        public Student()
        {

        }
    }
}
