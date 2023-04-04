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
using static System.Net.Mime.MediaTypeNames;

namespace StudentDiary.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReAddWorkerWindow.xaml
    /// </summary>
    public partial class ReAddWorkerWindow : Window
    {
        Worker Workerworker;
        public ReAddWorkerWindow(Worker worker)
        {
            InitializeComponent();
            try
            {
                Workerworker = worker;
                User user = Contex.User.ToList().Where(i => i.IdUser == worker.IdUser).FirstOrDefault();
                TbName.Text = user.FirstName;
                TbLastName.Text = user.LastName;
                TbPatronymic.Text = user.Patronymic;
                DB.Authorization authorization = Contex.Authorization.ToList().Where(i => i.IdLogin == user.IdLogin).FirstOrDefault();
                TbLoginW.Text = authorization.Login;
                TbPassword.Text = authorization.Password;
                TbPhone.Text = user.Phone;
                TbBird.Text = user.DateOfBirth.ToString();
                CbGender.ItemsSource = Contex.Gender.ToList();
                CbGender.DisplayMemberPath = "NameGender";
                CbGender.SelectedItem = Contex.Gender.ToList().Where(i => i.IdGender == user.IdGender).FirstOrDefault();
                CbRole.ItemsSource = Contex.Rol.ToList();
                CbRole.DisplayMemberPath = "NameRol";
                CbRole.SelectedItem = Contex.Rol.ToList().Where(i => i.IdRol == user.IdRol).FirstOrDefault();
                CbSA.ItemsSource = Contex.SubjectArea.ToList();
                CbSA.DisplayMemberPath = "NameSubjectArea";
                CbSA.SelectedItem = Contex.SubjectArea.ToList().Where(i => i.IdSubjectArea == worker.IdSubjectArea).FirstOrDefault();
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
            Workerworker.IdSubjectArea = (CbSA.SelectedItem as SubjectArea).IdSubjectArea;
            User user = Contex.User.ToList().Where(i => i.IdUser == Workerworker.IdUser).FirstOrDefault();
            user.IdRol = (CbRole.SelectedItem as Rol).IdRol;
            user.IdGender = (CbGender.SelectedItem as Gender).IdGender;
            user.FirstName = TbName.Text;
            user.LastName = TbLastName.Text;
            user.Patronymic = TbPatronymic.Text;
            user.Phone = TbPhone.Text;
            user.DateOfBirth = Convert.ToDateTime(TbBird.Text);
            DB.Authorization authorization = new DB.Authorization();
            authorization.Login = TbLoginW.Text;
            authorization.Password = TbPassword.Text;
            Contex.SaveChanges();
        }
    }
}
