using System.Windows;
using System.Windows.Controls;

namespace Практика_5
{
    public partial class GroupFormPage : Page
    {
        private StudyGroup group;
        private bool isNew;

        public GroupFormPage(StudyGroup selectedGroup)
        {
            InitializeComponent();

            group = selectedGroup;

            isNew = !AppData.Groups.Contains(group);

            if (isNew)
            {
                group.Id = AppData.NextId();
                TitleText.Text = "Новая группа";
            }
            else
            {
                TitleText.Text = "Редактирование группы";
            }

            DataContext = group;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(group.Name))
            {
                MessageBox.Show("Введите название группы");
                return;
            }

            if (string.IsNullOrWhiteSpace(group.Speciality))
            {
                MessageBox.Show("Введите специальность");
                return;
            }

            if (group.Course < 1 || group.Course > 6)
            {
                MessageBox.Show("Курс должен быть от 1 до 6");
                return;
            }

            if (isNew)
            {
                AppData.Groups.Add(group);
            }

            AppData.Save();
            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentFormPage(group.Students, new Student()));
        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            Student student = StudentsList.SelectedItem as Student;

            if (student == null)
            {
                MessageBox.Show("Сначала выберите студента");
                return;
            }

            NavigationService.Navigate(new StudentFormPage(group.Students, student));
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            Student student = StudentsList.SelectedItem as Student;

            if (student == null)
            {
                MessageBox.Show("Сначала выберите студента");
                return;
            }

            MessageBoxResult result = MessageBox.Show(
                "Удалить студента \"" + student.FullName + "\"?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                group.Students.Remove(student);
            }
        }
    }
}
