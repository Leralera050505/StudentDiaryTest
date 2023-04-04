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
using StudentDiary.DB;
using StudentDiary.Windows;
using static StudentDiary.HelpClass.EFClass;

namespace StudentDiary.Pages
{
    /// <summary>
    /// Логика взаимодействия для GradeStudentPage.xaml
    /// </summary>
    public partial class GradeStudentPage : Page
    {
       
        
        public GradeStudentPage()
        {
            MainWindow mainWindow = new MainWindow();
            Authorization authorization = new Authorization();
            InitializeComponent();
           
         //   if (mainWindow.TbLogin.Text == authorization.Login)
          //  {
                listviewLeson.ItemsSource = Contex.Journal.ToList(); 
          //  }
            
        }

      
    }
}
