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

using System.IO;
using StudentDiary.DB;
using static Microsoft.Win32.OpenFileDialog;
using Microsoft.Win32;
using StudentDiary.HelpClass;
using static StudentDiary.HelpClass.EFClass;


namespace StudentDiary.Windows
{
    /// <summary>
    /// Логика взаимодействия для StudentAddWindow.xaml
    /// </summary>
    public partial class StudentAddWindow : Window
    {
        public StudentAddWindow()
        {
            InitializeComponent();
            CbGender.ItemsSource = Contex.Gender.ToList();
            CbGender.SelectedIndex = 0;
            CbGender.DisplayMemberPath = "NameGender";

            CbRole.ItemsSource = Contex.Rol.ToList();
            CbRole.SelectedIndex = 0;
            CbRole.DisplayMemberPath = "NameRol";

            CBGroup.ItemsSource= Contex.Group.ToList();
            CBGroup.SelectedIndex = 0;
            CBGroup.DisplayMemberPath = "NameGroup";
        }

        private void btnAddW_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();
            
            authorization.Password = TbPassword.Text;
            authorization.Login = TbLogin1.Text;
            Contex.Authorization.Add(authorization);
            Contex.SaveChanges();
            User user = new User();
            user.FirstName = TbFirstName.Text;
            user.LastName = TbLastName.Text;
            user.Patronymic= TbPatronymic.Text;
            user.Phone= TbPhone.Text;
            user.DateOfBirth = Convert.ToDateTime(TbBird.Text);
            user.IdGender = (CbGender.SelectedItem as DB.Gender).IdGender;
            user.IdRol = (CbRole.SelectedItem as DB.Rol).IdRol;
            user.IdLogin = Contex.Authorization.ToList().Where(i => i.Login == authorization.Login).FirstOrDefault().IdLogin;
            Contex.User.Add(user);
            Contex.SaveChanges();
            Student student = new Student();
            student.IdUser = Contex.User.ToList().Where(i => i.IdUser == user.IdUser).FirstOrDefault().IdUser;
            student.IdGroup = (CBGroup.SelectedItem as DB.Group).IdGroup;
            Contex.Student.Add(student);
            Contex.SaveChanges();
            MessageBox.Show("Добавление прошло успешно");
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
