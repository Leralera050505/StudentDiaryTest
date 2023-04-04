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
using System.IO;
using StudentDiary.DB;
using static Microsoft.Win32.OpenFileDialog;
using Microsoft.Win32;
using StudentDiary.HelpClass;
using static StudentDiary.HelpClass.EFClass;
using System.Windows.Media.TextFormatting;

namespace StudentDiary.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWorkerWindow.xaml
    /// </summary>
    public partial class AddWorkerWindow : Window
    {
     
        public AddWorkerWindow()
        {
            InitializeComponent();
            CbGender.ItemsSource = Contex.Gender.ToList();
            CbGender.SelectedIndex = 0;
            CbGender.DisplayMemberPath = "NameGender";

            CbRole.ItemsSource = Contex.Rol.ToList();
            CbRole.SelectedIndex = 0;
            CbRole.DisplayMemberPath = "NameRol";

            CbSA.ItemsSource=Contex.SubjectArea.ToList();
            CbSA.SelectedIndex = 0;
            CbSA.DisplayMemberPath = "NameSubjectArea";

        
        }

        private void btnAddW_Click(object sender, RoutedEventArgs e)
        {
            Authorization authorization = new Authorization();

            authorization.Password = TbPassword.Text;
            authorization.Login = TbLoginW.Text;
            Contex.Authorization.Add(authorization);
            Contex.SaveChanges();
            User user = new User();
            user.FirstName = TbName.Text;
            user.LastName = TbLastName.Text;
            user.Patronymic = TbPatronymic.Text;
            user.Phone = TbPhone.Text;
            user.DateOfBirth = Convert.ToDateTime(TbBird.Text);
            user.IdGender = (CbGender.SelectedItem as DB.Gender).IdGender;
            user.IdRol = (CbRole.SelectedItem as DB.Rol).IdRol;
            user.IdLogin = Contex.Authorization.ToList().Where(i => i.Login == authorization.Login).FirstOrDefault().IdLogin;
            Contex.User.Add(user);
            Contex.SaveChanges();
            Worker worker = new Worker();
            worker.IdUser  = Contex.User.ToList().Where(i => i.IdUser == user.IdUser).FirstOrDefault().IdUser;
            worker.SubjectArea = (CbSA.SelectedItem as SubjectArea);
            Contex.Worker.Add(worker);
            Contex.SaveChanges();//ll
            MessageBox.Show("Добавление прошло успешно");
            //сделать обновление инфы в приложении
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
