using Classrooms;
using System.ComponentModel;
using System.ComponentModel.Design;
using static a.Helper;

namespace a;

public class Classroom
{
    public int ID { get; set; }
    public string Name { get; set; }
    public ClassroomType Type { get; set; }

    public List<Student> Students = new List<Student>();
    public enum ClassroomType
    {
        Backend,
        Fronted
    }

    public Classroom(int id, string name, ClassroomType type)
    {
        ID = id;
        Name = name;
        Type = type;
    }
    public void AddStudent(Student student)
    {
        int limit = (Type == ClassroomType.Backend) ? 20 : 15;
        if (Students.Count >= limit)
        {
            Console.WriteLine($"Limit keçildi! ({limit} tələbə limiti)");
            return;
        }
        Students.Add(student);

    }

    public Student FindId(int id)
    {
        foreach (Student s in Students)
        {
            if (s.Id == id)
            {
                return s;
            }
        }

        return null;
    }

    public void Delete(int id)
    {
        Student st = FindId(id);
        if (st == null) throw new StudentNotFoundException();
        Students.Remove(st);
    }


    public void CreateClassroom(List<Classroom> classrooms)
    {
        Console.WriteLine("Classroom adini daxil edin: ");
        string name = Console.ReadLine();
        bool isValid = false;
        if (name.Length == 5)
        {
            bool isLetters = char.IsUpper(name[0]) && char.IsUpper(name[1]);
            bool isDigits = char.IsDigit(name[2]) && char.IsDigit(name[3]) && char.IsDigit(name[4]);

            if (isLetters && isDigits)
            {
                isValid = true;
            }
        }

        if (isValid)
        {
            Console.WriteLine(" Classroom name doğrudur!");
        }
        else
        {
            Console.WriteLine(" Classroom name yanlışdır!");
        }

        Console.Write("Sinif tipi (Backend/Frontend): ");
        string type = Console.ReadLine();

        Console.WriteLine("Classroom Id: ");
        int id = int.Parse(Console.ReadLine());

        ClassroomType classroomType = (ClassroomType)Enum.Parse(typeof(ClassroomType), type, true); //yadda saxla
        Classroom newClassroom = new Classroom(id,name,classroomType);
        classrooms.Add(newClassroom);
        DataManager.Save(classrooms);
        Console.WriteLine("Sinif yaradıldı!");
    }

}




