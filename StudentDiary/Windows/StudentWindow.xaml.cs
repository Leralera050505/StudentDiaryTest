using StudentDiary.HelpClass;
using StudentDiary.Pages;
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

namespace StudentDiary.Windows
{
    /// <summary>
    /// Логика взаимодействия для StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();

            Navigation.frame = frameName;
            Navigation.frame.Navigate(new Page());
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frame.Navigate(new MenuPageStudent());
        }

        private void btnLesson_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frame.Navigate(new TimeTablePage());
        }

        private void btnGrade_Click(object sender, RoutedEventArgs e)
        {
            Navigation.frame.Navigate(new GradeStudentPage());
        }
    

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
