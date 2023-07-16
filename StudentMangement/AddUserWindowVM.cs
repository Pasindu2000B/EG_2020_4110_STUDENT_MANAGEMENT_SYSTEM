using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentMangement;
using Microsoft.Win32;
using Microsoft.Windows.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace StudentMangement
{
    public partial class AddUserVM : ObservableObject

    {


        [ObservableProperty]
        public string firstname;


        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public DateTime dateofbirth;


        public double gpa;

        [ObservableProperty]
        public string gp;




        [ObservableProperty]
        public BitmapImage selectedImage;

        public void CloseWindow()
        {
            // get the current window
            Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            // close the window
            window.Close();
        }


        public AddUserVM(Student Student)
        {


            firstname = Student.FirstName;
            lastname = Student.LastName;
            age = Student.Age;
            gpa = Student.GPA;
            dateofbirth = Student.DateOfBirth;
            selectedImage = Student.Image;
            gp = Student.GPA.ToString();

        }
        public AddUserVM()
        {
            dateofbirth = DateTime.Now;
            firstname = "";



        }


        //get image 
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));




                MessageBox.Show("Imgae successfuly uploded!", "successfull");
            }
        }






        public Student Student { get; private set; }


        [RelayCommand]
        public void Save()
        {
            bool gpok = false;

            if (gp == null)
            {
                MessageBox.Show(("GPA IS NULL"));
                return;
            }
            int count = 0;
            foreach (var le in gp)
            {

                if (le == '.')
                {
                    count++;
                }

            }
            foreach (var letter in gp)
            {
                if ((letter == '0' || letter == '1' || letter == '2' || letter == '3' || letter == '4' || letter == '5' || letter == '6' || letter == '7' || letter == '8' || letter == '9') || (letter == '.' && count == 1))
                {
                    gpok = true;
                    break;
                }

            }
            if (gpok)
            {

                gpa = double.Parse(gp);



                if (gpa < 0 || gpa > 4)
                {
                    MessageBox.Show("GPA value must be between 0 and 4.", "Error");
                    return;
                }
                if (string.IsNullOrWhiteSpace(firstname) || string.IsNullOrWhiteSpace(lastname))
                {
                    MessageBox.Show("First name and last name cannot be empty.", "Error");
                    return;
                }

                if (!Regex.IsMatch(firstname, @"^[a-zA-Z\s]+$") || !Regex.IsMatch(lastname, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("First name and last name must contain only letters and spaces.", "Error");
                    return;
                }
                if (selectedImage == null)
                {
                    MessageBox.Show("Please Upload Image");
                    return;

                }

                if (Student == null)
                {

                    Student = new Student()
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Age = age,
                        DateOfBirth = dateofbirth,
                        Image = selectedImage,

                        GPA = gpa

                    };


                }
                else
                {

                    Student.FirstName = firstname;
                    Student.LastName = lastname;
                    Student.Age = age;
                    Student.GPA = gpa;
                    Student.Image = selectedImage;
                    Student.DateOfBirth = dateofbirth;



                }
                CloseWindow();
                Application.Current.MainWindow.Show();


            }
            else
            {
                MessageBox.Show("Gpa value is not number");
                return;
            }
        }
    }


}
