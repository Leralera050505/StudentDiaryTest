using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentDiary.DB;
using StudentDiary.Windows;
using static StudentDiary.HelpClass.EFClass;

namespace StudentDiary.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class StudentPage : Page
    {

        List<Student> students = new List<Student>();
        List<string> sortList = new List<string>()
        {
            "По умолчанию",
            "По фамилии",
            "По имени",
            "По логину"
            
        };
        public StudentPage()
        {
            InitializeComponent();
            CmbSort.ItemsSource = sortList;
            CmbSort.SelectedIndex = 0;
            GetListStudent();
            listviewUsers.ItemsSource = Contex.Student.ToList();
        }

        private void GetListStudent()
        {
            students = Contex.Student.ToList();

            //поиск

            students = students.
                Where(i => i.User.LastName.Contains(TxbSearch.Text) 
               || i.User.FirstName.Contains(TxbSearch.Text)
               || i.User.Authorization.Login.Contains(TxbSearch.Text)
               ).ToList();

            //сортировка

            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    students = students.OrderBy(i => i.IdUser).ToList();
                    break;

                case 1:
                    students = students.OrderBy(i => i.User.LastName).ToList();
                    break;

                case 2:
                    students = students.OrderBy(i => i.User.FirstName).ToList();
                    break;

                case 3:
                    students = students.OrderBy(i => i.User.Authorization.Login).ToList();
                    break;
                default:
                    break;
            }
            listviewUsers.ItemsSource = students;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            StudentAddWindow studentAddWindow = new StudentAddWindow();
            studentAddWindow.Show();
            //   AdminWindow.Close();
            listviewUsers.ItemsSource = Contex.Student.ToList();
        }

        private void btnRe_Click(object sender, RoutedEventArgs e)
        {
            ReAddStudentWindow reAddStudentWindow = new ReAddStudentWindow(listviewUsers.SelectedItem as Student);
            reAddStudentWindow.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Student student = listviewUsers.SelectedItem as Student;
                User user = Contex.User.ToList().Where(i => i.IdUser == student.IdUser).FirstOrDefault();
                Authorization authorization = Contex.Authorization.ToList().Where(i => i.IdLogin == user.IdLogin).FirstOrDefault();
                Contex.Student.Remove(student);
                Contex.SaveChanges();
                Contex.User.Remove(user);
                Contex.SaveChanges();
                Contex.Authorization.Remove(authorization);
                Contex.SaveChanges();
                listviewUsers.ItemsSource = Contex.Student.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            listviewUsers.ItemsSource = Contex.Student.ToList();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListStudent();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListStudent();
        }

      
    }
}
