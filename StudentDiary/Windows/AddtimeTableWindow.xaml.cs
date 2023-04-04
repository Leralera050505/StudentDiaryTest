using StudentDiary.DB;
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

using static StudentDiary.HelpClass.EFClass;
namespace StudentDiary.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddLessonWindow.xaml
    /// </summary>
    public partial class AddLessonWindow : Window
    {
        public AddLessonWindow()
        {
            InitializeComponent();
            CbLesson.ItemsSource = Contex.Lesson.ToList();
            CbLesson.DisplayMemberPath = "NameLesson";
            CbLesson.SelectedIndex = 0;
            CbGroup.ItemsSource= Contex.Group.ToList();
            CbGroup.SelectedIndex = 0;
            CbGroup.DisplayMemberPath = "NameGroup";
            CbWorker.ItemsSource= Contex.Worker.ToList();
            CbWorker.SelectedIndex = 0;
            CbWorker.DisplayMemberPath = "IdWorker";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TimeTable timeTable = new TimeTable();
                timeTable.IdLesson = (CbLesson.SelectedItem as Lesson).IdLesson;
                timeTable.IdWorker = (CbWorker.SelectedItem as Worker).IdWorker;
                timeTable.IdGroup = (CbGroup.SelectedItem as Group).IdGroup;
                timeTable.TimeLesson = TimeSpan.Zero;
                timeTable.DateLesson = Convert.ToDateTime(DpDateLesson.Text).Date;
                Contex.TimeTable.Add(timeTable);
                //listviewLeson.ItemsSource = Contex.Lesson.ToList();
                Contex.SaveChanges();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
