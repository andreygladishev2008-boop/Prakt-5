using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Практика_5
{
    public partial class GroupsPage : Page
    {
        public GroupsPage()
        {
            InitializeComponent();
            DataContext = this;
        }

        public ObservableCollection<StudyGroup> Groups
        {
            get { return AppData.Groups; }
        }

        public StudyGroup SelectedGroup { get; set; }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GroupFormPage(new StudyGroup()));
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGroup == null)
            {
                MessageBox.Show("Сначала выберите группу");
                return;
            }

            NavigationService.Navigate(new GroupFormPage(SelectedGroup));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedGroup == null)
            {
                MessageBox.Show("Сначала выберите группу");
                return;
            }

            MessageBoxResult result = MessageBox.Show(
                "Удалить группу \"" + SelectedGroup.Name + "\"?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Groups.Remove(SelectedGroup);
                SelectedGroup = null;
                AppData.Save();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            AppData.Save();
            MessageBox.Show("Данные сохранены в groups.json");
        }
    }
}
