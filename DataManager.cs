using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Classrooms
{
    public static class DataManager
    {
        private const string FilePath = "data.json";

        public static void Save(List<a.Classroom> classrooms)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText(FilePath, JsonSerializer.Serialize(classrooms, options));
        }

        public static List<a.Classroom> Load()
        {
            if (!File.Exists(FilePath)) return new List<a.Classroom>();
            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<a.Classroom>>(json) ?? new List<a.Classroom>();
        }
    }
}
