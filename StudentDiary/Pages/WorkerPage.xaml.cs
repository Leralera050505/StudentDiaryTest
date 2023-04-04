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
using System.Windows.Navigation;
using System.Windows.Shapes;
using  StudentDiary.HelpClass;
using StudentDiary.DB;
using static StudentDiary.HelpClass.EFClass;
using System.Data.Entity;
using System.Data.SqlClient;
using StudentDiary.Windows;

namespace StudentDiary.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        List<Worker> workers = new List<Worker>();
        List<string> sortList = new List<string>()
        {
            "По умолчанию",
            "По фамилии",
            "По имени",
            "По логину",
        };
        public WorkerPage()
        {
            InitializeComponent();
            CmbSort.ItemsSource = sortList;
            CmbSort.SelectedIndex = 0;
            GetListWoker();
            listviewUsers.ItemsSource = Contex.Worker.ToList(); 
        }

        private void GetListWoker()
        {
            workers = Contex.Worker.ToList();

            //поиск

            workers = workers.
                Where(i => i.User.LastName.Contains(TxbSearch.Text)
               || i.User.FirstName.Contains(TxbSearch.Text)
               || i.User.Authorization.Login.Contains(TxbSearch.Text)
               ).ToList();

            //сортировка

            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    workers = workers.OrderBy(i => i.IdUser).ToList();
                    break;

                case 1:
                    workers = workers.OrderBy(i => i.User.LastName).ToList();
                    break;

                case 2:
                    workers = workers.OrderBy(i => i.User.FirstName).ToList();
                    break;

                case 3:
                    workers = workers.OrderBy(i => i.User.Authorization.Login).ToList();
                    break;
                default:
                    break;
            }
            listviewUsers.ItemsSource = workers;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWorkerWindow addWorkerWindow = new AddWorkerWindow();
            addWorkerWindow.Show();
            
        }
        private void btnRe_Click(object sender, RoutedEventArgs e)
        {
            ReAddWorkerWindow reAddWorkerWindow = new ReAddWorkerWindow(listviewUsers.SelectedItem as Worker);
            reAddWorkerWindow.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Worker worker = listviewUsers.SelectedItem as Worker;
                User user = Contex.User.ToList().Where(i => i.IdUser == worker.IdUser).FirstOrDefault();
                Authorization authorization = Contex.Authorization.ToList().Where(i => i.IdLogin == user.IdLogin).FirstOrDefault();
                Contex.Worker.Remove(worker);
                Contex.SaveChanges();
                Contex.User.Remove(user);
                Contex.SaveChanges();
                Contex.Authorization.Remove(authorization);
                Contex.SaveChanges();
                listviewUsers.ItemsSource = Contex.Worker.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            listviewUsers.ItemsSource = Contex.Worker.ToList();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListWoker();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListWoker();
        }

    
    }
}
