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

namespace StudentDiary.Pages //--вход Студента
{
    /// <summary>
    /// Логика взаимодействия для LessonStudentPage.xaml
    /// </summary>
    public partial class TimeTablePage : Page
    {
        List<TimeTable> timeTables = new List<TimeTable>();
        List<string> sortList = new List<string>()
        {
            "По умолчанию",
            "По фамилии",
            "По имени",
            "По предмету",
            "По группе"
        };
        public TimeTablePage()
        {
            InitializeComponent();
            CmbSort.ItemsSource = sortList;
            CmbSort.SelectedIndex = 0;
            GetListTimeTable();
            listviewLeson.ItemsSource = Contex.TimeTable.ToList();

        }
        private void GetListTimeTable()
        {
            timeTables = Contex.TimeTable.ToList();

            timeTables = timeTables.
                Where(i => i.Lesson.NameLesson.Contains(TxbSearch.Text)
                || i.Worker.User.LastName.Contains(TxbSearch.Text)
                || i.Worker.User.FirstName.Contains(TxbSearch.Text)
                || i.Group.NameGroup.Contains(TxbSearch.Text)
                ).ToList();

            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    timeTables = timeTables.OrderBy(i => i.IdTimeTable).ToList();
                    break;

                case 1:
                    timeTables = timeTables.OrderBy(i => i.Worker.User.LastName).ToList();
                    break;

                case 2:
                    timeTables = timeTables.OrderBy(i => i.Worker.User.FirstName).ToList();
                    break;

                case 3:
                    timeTables = timeTables.OrderBy(i => i.Lesson.NameLesson).ToList();
                    break;
                case 4:
                    timeTables = timeTables.OrderBy(i => i.Group.NameGroup).ToList();
                    break;
                default:
                    break;
            }
            listviewLeson.ItemsSource = timeTables;

        }
        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetListTimeTable();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetListTimeTable();
        }
    }
}
