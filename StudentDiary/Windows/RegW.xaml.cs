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
using StudentDiary.HelpClass;
using static StudentDiary.HelpClass.EFClass;

namespace StudentDiary.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegW.xaml
    /// </summary>
    public partial class RegW : Window
    {
        public RegW()
        {
            InitializeComponent();

            CbGender.ItemsSource = Contex.Gender.ToList();
            CbGender.SelectedIndex =0;
            CbGender.DisplayMemberPath = "NameGender";

            CbRole.ItemsSource=Contex.Rol.ToList();
            CbRole.SelectedIndex = 0;
            CbRole.DisplayMemberPath = "NameRol";
        }
        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {


            if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым");
                return;
            }

            var Login = Contex.Authorization.ToList()
                .Where(i => i.Login == TbLogin.Text && i.Password == TbPassword.Text).FirstOrDefault();

            var User = Contex.User.ToList().Where(i => i.LastName == TbLastName.Text && i.FirstName == TbNAme.Text
            && i.Patronymic == TbPatronymic.Text && i.Phone == TbPhone.Text);
            if ((User != null) && (Login != null))
            {
                MessageBox.Show("Логин занят");
            }
            else if ((User != null) && (Login != null))
            {
                MessageBox.Show("Логин занят");
            }
            DB.User user = new DB.User();
            DB.Authorization authorization = new Authorization();
            user.LastName= TbLastName.Text;
            user.FirstName= TbNAme.Text;
            user.Phone= TbPhone.Text;
            user.Patronymic= TbPatronymic.Text;
            user.IdGender = (CbGender.SelectedItem as DB.Gender).IdGender;
            user.IdRol = (CbRole.SelectedItem as DB.Rol).IdRol; 
            authorization.Login = TbLogin.Text;
            authorization.Password = TbPassword.Text;


            Contex.Authorization.Add(authorization);
            authorization.Login = TbLogin.Text;
            authorization.Password = TbPassword.Text;
            Contex.User.Add(user);
            Contex.SaveChanges();
            MessageBox.Show("Добавление прошло успешно");
        }
        private void txtAuth_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void txtAuth_MouseEnter(object sender, MouseEventArgs e)
        {
            var tc = new BrushConverter();
            txtAuth.Foreground = (Brush)tc.ConvertFrom("#284D79");
        }
        private void txtAuth_MouseLeave(object sender, MouseEventArgs e)
        {
            txtAuth.Foreground = Brushes.White;
        }
    }
}
