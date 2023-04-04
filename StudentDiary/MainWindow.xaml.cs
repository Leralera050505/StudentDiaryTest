using StudentDiary.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using StudentDiary.HelpClass;
using static StudentDiary.HelpClass.EFClass;
using StudentDiary.Pages;


namespace StudentDiary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GenerateCaptcha();
        }

        private void btnReCapcha_Click(object sender, RoutedEventArgs e)
        {
            GenerateCaptcha();
        }

        private void txtReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
          RegW regW = new RegW();
        regW.Show();
          this.Close();
        }

        private void txtReg_MouseEnter(object sender, MouseEventArgs e)
        {
            var tc = new BrushConverter();
            txtReg.Foreground = (Brush)tc.ConvertFrom("#284D79");

        }

        private void txtReg_MouseLeave(object sender, MouseEventArgs e)
        {
            txtReg.Foreground = Brushes.White;
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            if (TbCapcha.Text != tbPicCapcha.Text)
            {
                MessageBox.Show("Капча введена не верно", "Предупреждение");
            }
            else if (string.IsNullOrWhiteSpace(TbLogin.Text))
            {
                MessageBox.Show("Логин не может быть пустым", "Предупреждение");
            }
            else if (string.IsNullOrWhiteSpace(TbPassword.Text))
            {
                MessageBox.Show("Пароль не может быть пустым", "Предупреждение");
            }
            else if (string.IsNullOrWhiteSpace(TbCapcha.Text))
            {
                MessageBox.Show("Поле с капчей не может быть пустым", "Предупреждение");
            }
            
            else
            {
                var Login = Contex.Authorization.ToList()
            .Where(i => i.Login == TbLogin.Text && i.Password == TbPassword.Text).FirstOrDefault();
                var User = Contex.User.ToList().Where(i => i.IdLogin == Login.IdLogin).FirstOrDefault();
                try
                {
                    var Worker = Contex.Worker.ToList().Where(i => i.IdUser == User.IdUser).FirstOrDefault();
                    var Student = Contex.Student.ToList().Where(i => i.IdUser == i.User.IdUser).FirstOrDefault();

                    if ((Worker != null) && (Login != null))
                    {
                        AdminWindow adminWindow = new AdminWindow();
                        MenuPage menuPage = new MenuPage();
                        adminWindow.Show();
                        Navigation.frame.Navigate(new MenuPage());
                        Close();
                    }
                    else if ((Student != null) && (Login != null))
                    {
                        StudentWindow studentWindow = new StudentWindow();
                        studentWindow.Show();
                        MessageBox.Show("Student");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void GenerateCaptcha() {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z,1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = " ";
            Random r = new Random();

            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            tbPicCapcha.Text = pwd;
            TbCapcha
                .Text = pwd;
        }
    }
}
