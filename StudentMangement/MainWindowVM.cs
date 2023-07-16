using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentMangement;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace StudentMangement
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> students;

        public void CloseWindow()
        {
            // get the current window
            Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            // close the window
            window.Close();
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm != null && vm.Student != null && vm.Student.FirstName != null)
            {
                Students.Add(vm.Student);


            }

        }
        [RelayCommand]
        public void DeleteStudent(object obj)
        {
            if (obj is Student student)
            {
                string name = student.FirstName;
                students.Remove(student);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");

            }

        }
        [RelayCommand]
        public void EDITUSER(object obj)
        {
            if (obj is Student student)
            {
                var vm = new AddUserVM(student);
                var window = new AddUserWindow(vm);

                window.ShowDialog();


                int index = students.IndexOf(student);
                students.RemoveAt(index);
                students.Insert(index, vm.Student);



            }

        }






        public MainWindowVM()
        {
            students = new ObservableCollection<Student>();
            BitmapImage image1 = new BitmapImage(new Uri("/Images/7.png", UriKind.Relative));
            DateTime dob1 = new DateTime(2000, 12, 05);
            students.Add(new Student("Nithil", "Sheshan", dob1, image1, 2));
            BitmapImage image2 = new BitmapImage(new Uri("/Images/6.png", UriKind.Relative));
            DateTime dob2 = new DateTime(1977, 05, 27);
            students.Add(new Student("Yasindu", "Amantha", dob2, image2, 1));
            BitmapImage image3 = new BitmapImage(new Uri("/Images/5.png", UriKind.Relative));
            DateTime dob3 = new DateTime(2000, 3, 8);
            students.Add(new Student("Lasith", "Perera", dob3, image3, 2));
            BitmapImage image4 = new BitmapImage(new Uri("/Images/4.png", UriKind.Relative));
            DateTime dob4 = new DateTime(2000, 12, 05);
            students.Add(new Student("Mayumi", "Batuwatta", dob4, image4, 2.4));



        }
    }
}
