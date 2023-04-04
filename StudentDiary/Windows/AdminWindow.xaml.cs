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
using StudentDiary.Pages;
using StudentDiary.HelpClass;
using System.Runtime.Remoting.Channels;

namespace StudentDiary.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
         public AdminWindow()
        {
            InitializeComponent();
            Navigation.frame = frameName;
            Navigation.frame.Navigate(new Page());
            
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frame.Navigate(new MenuPage());
        }

        private void btnWorker_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frame.Navigate(new WorkerPage());
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frame.Navigate(new StudentPage());
        }

        private void btnDelivery_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frame.Navigate(new LessonPage());
        }

       
    }
}
