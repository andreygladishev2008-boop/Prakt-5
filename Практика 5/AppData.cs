using System.Collections.ObjectModel;

namespace Практика_5
{
    public static class AppData
    {
        public static ObservableCollection<StudyGroup> Groups { get; set; }

        static AppData()
        {
            Groups = JsonService.Load();

            if (Groups.Count == 0)
            {
                StudyGroup group1 = new StudyGroup();
                group1.Id = 1;
                group1.Name = "ИС-21";
                group1.Speciality = "Информационные системы и программирование";
                group1.Course = 2;
                group1.Students.Add(new Student() { FullName = "Иванов Иван", Age = 18, AverageGrade = 4.5 });
                group1.Students.Add(new Student() { FullName = "Петров Петр", Age = 19, AverageGrade = 4.2 });
                group1.Students.Add(new Student() { FullName = "Сидорова Анна", Age = 18, AverageGrade = 4.8 });
                Groups.Add(group1);

                StudyGroup group2 = new StudyGroup();
                group2.Id = 2;
                group2.Name = "ПИ-22";
                group2.Speciality = "Прикладная информатика";
                group2.Course = 1;
                group2.Students.Add(new Student() { FullName = "Смирнов Алексей", Age = 17, AverageGrade = 4.0 });
                group2.Students.Add(new Student() { FullName = "Кузнецова Мария", Age = 17, AverageGrade = 4.7 });
                Groups.Add(group2);
            }
        }

        public static int NextId()
        {
            int maxId = 0;
            foreach (StudyGroup group in Groups)
            {
                if (group.Id > maxId)
                {
                    maxId = group.Id;
                }
            }

            return maxId + 1;
        }

        public static void Save()
        {
            JsonService.Save(Groups);
        }
    }
}
