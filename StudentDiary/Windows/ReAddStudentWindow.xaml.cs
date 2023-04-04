using StudentDiary.DB;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using static StudentDiary.HelpClass.EFClass;
namespace StudentDiary.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReAddStudentWindow.xaml
    /// </summary>
    public partial class ReAddStudentWindow : Window
    {

        Student student1;
        public ReAddStudentWindow(Student student)
        {
            InitializeComponent();
            try
            {
                student1 = student;
                User user = Contex.User.ToList().Where(i => i.IdUser == student.IdUser).FirstOrDefault();
                TbFirstName.Text = user.FirstName;
                TbLastName.Text = user.LastName;
                TbPatronymic.Text = user.Patronymic;
                DB.Authorization authorization = Contex.Authorization.ToList().Where(i => i.IdLogin == user.IdLogin).FirstOrDefault();
                TbLogin1.Text = authorization.Login;
                TbPassword.Text = authorization.Password;
                TbPhone.Text = user.Phone;
                TbBird.Text = user.DateOfBirth.ToString();
                CbGender.ItemsSource = Contex.Gender.ToList();
                CbGender.DisplayMemberPath = "NameGender";
                CbGender.SelectedItem = Contex.Gender.ToList().Where(i => i.IdGender == user.IdGender).FirstOrDefault();
                CbRole.ItemsSource = Contex.Rol.ToList();
                CbRole.DisplayMemberPath = "NameRol";
                CbRole.SelectedItem = Contex.Rol.ToList().Where(i => i.IdRol == user.IdRol).FirstOrDefault();
                CBGroup.ItemsSource = Contex.Group.ToList();
                CBGroup.DisplayMemberPath = "NameGroup";
                CBGroup.SelectedItem = Contex.Group.ToList().Where(i => i.IdGroup == student.IdGroup).FirstOrDefault();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddW_Click(object sender, RoutedEventArgs e)
        {
            User user = Contex.User.ToList().Where(i => i.IdUser == student1.IdUser).FirstOrDefault();
            user.IdRol = (CbRole.SelectedItem as Rol).IdRol;
            user.IdGender = (CbGender.SelectedItem as Gender).IdGender;
            user.FirstName = TbFirstName.Text;
            user.LastName = TbLastName.Text;
            user.Patronymic = TbPatronymic.Text;
            user.Phone = TbPhone.Text;
            user.DateOfBirth = Convert.ToDateTime(TbBird.Text);
            DB.Authorization authorization = new DB.Authorization();
            authorization.Login = TbLogin1.Text;
            authorization.Password = TbPassword.Text;
            student1.IdGroup = (CBGroup.SelectedItem as Group).IdGroup;
            Contex.SaveChanges();
        }
    }

}
