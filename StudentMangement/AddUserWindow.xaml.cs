using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentMangement
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow(AddUserVM vm)

        {
            InitializeComponent();
            DataContext = vm;
            var viewmodel = DataContext as AddUserVM;
            ImageBrush imagebrush = new ImageBrush(viewmodel.selectedImage);
            preview.Fill = imagebrush;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Window window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            // close the window
            window.Close();

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }




        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            var viewmodel = DataContext as AddUserVM;
            ImageBrush imagebrush = new ImageBrush(viewmodel.selectedImage);
            preview.Fill = imagebrush;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewmodel = DataContext as AddUserVM;
            ImageBrush imagebrush = new ImageBrush(viewmodel.selectedImage);
            preview.Fill = imagebrush;

        }
    }
}
