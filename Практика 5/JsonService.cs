using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Практика_5
{
    public static class JsonService
    {
        private static string FileName
        {
            get { return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "groups.json"); }
        }

        public static void Save(ObservableCollection<StudyGroup> groups)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ObservableCollection<StudyGroup>));

            using (FileStream stream = new FileStream(FileName, FileMode.Create))
            {
                serializer.WriteObject(stream, groups);
            }
        }

        public static ObservableCollection<StudyGroup> Load()
        {
            ObservableCollection<StudyGroup> groups = new ObservableCollection<StudyGroup>();

            if (!File.Exists(FileName))
            {
                return groups;
            }

            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ObservableCollection<StudyGroup>));

                using (FileStream stream = new FileStream(FileName, FileMode.Open))
                {
                    object data = serializer.ReadObject(stream);
                    groups = (ObservableCollection<StudyGroup>)data;
                }
            }
            catch
            {
                groups = new ObservableCollection<StudyGroup>();
            }

            return groups;
        }
    }
}
