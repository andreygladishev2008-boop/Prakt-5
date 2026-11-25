using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Практика_5
{
    // Страница добавления и редактирования студента
    public partial class StudentFormPage : Page
    {
        private ObservableCollection<Student> students;
        private Student student;
        private bool isNew;

        public StudentFormPage(ObservableCollection<Student> list, Student selectedStudent)
        {
            InitializeComponent();

            students = list;
            student = selectedStudent;

            // Если студента еще нет в списке, значит создаем нового.
            isNew = !students.Contains(student);

            if (isNew)
            {
                TitleText.Text = "Новый студент";
            }
            else
            {
                TitleText.Text = "Редактирование студента";
            }

            DataContext = student;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(student.FullName))
            {
                MessageBox.Show("Введите ФИО студента");
                return;
            }

            if (student.Age < 14 || student.Age > 100)
            {
                MessageBox.Show("Возраст должен быть от 14 до 100");
                return;
            }

            if (student.AverageGrade < 0 || student.AverageGrade > 5)
            {
                MessageBox.Show("Средний балл должен быть от 0 до 5");
                return;
            }

            if (isNew)
            {
                students.Add(student);
            }

            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
