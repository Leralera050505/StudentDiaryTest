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
    /// Логика взаимодействия для ReAddTimeTableWindow.xaml
    /// </summary>
    public partial class ReAddTimeTableWindow : Window
    {
        TimeTable timeTable1;
        public ReAddTimeTableWindow(TimeTable timeTable)
        {
            InitializeComponent();
            timeTable1 = timeTable;
            CbLesson.ItemsSource = Contex.Lesson.ToList();
            CbLesson.SelectedItem = Contex.Lesson.ToList().Where(i => i.IdLesson == timeTable.IdLesson).FirstOrDefault();
            CbLesson.DisplayMemberPath = "NameLesson";
            DpDateLesson.Text = timeTable.DateLesson.ToString();
            CbGroup.ItemsSource = Contex.Group.ToList();
            CbGroup.SelectedItem = Contex.Group.ToList().Where(i => i.IdGroup == timeTable.IdGroup).FirstOrDefault();
            CbGroup.DisplayMemberPath = "NameGroup";
            CbWorker.ItemsSource = Contex.Worker.ToList();
            CbWorker.SelectedItem = Contex.Worker.ToList().Where(i => i.IdWorker == timeTable.IdWorker).FirstOrDefault();
            CbWorker.DisplayMemberPath = "IdWorker";

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            TimeTable tt2 = Contex.TimeTable.ToList().Where(i => i.IdTimeTable == timeTable1.IdTimeTable).FirstOrDefault();
            tt2.DateLesson = Convert.ToDateTime(DpDateLesson.Text);
            tt2.IdLesson = (CbLesson.SelectedItem as Lesson).IdLesson;
            tt2.IdWorker = (CbWorker.SelectedItem as Worker).IdWorker;
            tt2.IdGroup = (CbGroup.SelectedItem as Group).IdGroup;
            Contex.SaveChanges();
        }
    }
}
