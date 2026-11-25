using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Практика_5
{
    public class StudyGroup : INotifyPropertyChanged
    {
        private int id;
        private string name = "";
        private string speciality = "";
        private int course;
        private ObservableCollection<Student> students = new ObservableCollection<Student>();

        public StudyGroup()
        {
            students.CollectionChanged += StudentsChanged;
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Speciality
        {
            get { return speciality; }
            set
            {
                speciality = value;
                OnPropertyChanged("Speciality");
            }
        }

        public int Course
        {
            get { return course; }
            set
            {
                course = value;
                OnPropertyChanged("Course");
            }
        }

        public ObservableCollection<Student> Students
        {
            get { return students; }
            set
            {
                students.CollectionChanged -= StudentsChanged;
                students = value;
                students.CollectionChanged += StudentsChanged;

                foreach (Student student in students)
                {
                    student.PropertyChanged += StudentChanged;
                }

                OnPropertyChanged("Students");
                OnPropertyChanged("GroupAverageGrade");
            }
        }

        public double GroupAverageGrade
        {
            get
            {
                if (students.Count == 0)
                {
                    return 0;
                }

                double sum = 0;
                foreach (Student student in students)
                {
                    sum += student.AverageGrade;
                }

                return sum / students.Count;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void StudentsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Student student in e.NewItems)
                {
                    student.PropertyChanged += StudentChanged;
                }
            }

            if (e.OldItems != null)
            {
                foreach (Student student in e.OldItems)
                {
                    student.PropertyChanged -= StudentChanged;
                }
            }

            OnPropertyChanged("GroupAverageGrade");
        }

        private void StudentChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AverageGrade")
            {
                OnPropertyChanged("GroupAverageGrade");
            }
        }
    }
}
