using a;
using Classrooms;
using System.Globalization;
using System.Xml.Linq;
using static a.Classroom;
using static a.Helper;

class Program {

    public void Main()
    {

        Console.WriteLine("Menyu: ");
        Console.WriteLine("1. Classroom yarat");
        Console.WriteLine("2. Student yarat");
        Console.WriteLine("3. Bütün telebeleri ekrana cixart");
        Console.WriteLine("4. Seçilmiş sinifdeki telebeleri ekrana cixart");
        Console.WriteLine("5. Telebe sil");

        Program p = new Program();

    restart:
        Console.WriteLine("Secim edin: ");
        int input = int.Parse(Console.ReadLine());


        switch (input)
        {
            case 1:
                List<Classroom> classrooms = new List<Classroom>();
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
                Classroom newClassroom = new Classroom(id, name, classroomType);
                classrooms.Add(newClassroom);
                DataManager.Save(classrooms);
                Console.WriteLine("Sinif yaradıldı!");
                break;





            case 2:
            List<Classroom> classroom = new List<Classroom>();
            
                if (classroom.Count == 0)
                {
                    throw new ClassroomNotFoundException();
                }

                Console.WriteLine("Adi daxil edin: ");
                string name_s = Console.ReadLine();
                Console.WriteLine("Surname: ");
                string surname = Console.ReadLine();
                Console.WriteLine("Id: ");
                int id_s = int.Parse(Console.ReadLine());


                Student student = new Student(id_s, name_s, surname);


                Classroom selected = classroom.FirstOrDefault(c => c.ID == id_s);
                if (selected == null) throw new StudentNotFoundException();

                selected.AddStudent(student);
                DataManager.Save(classroom);
                Console.WriteLine(" Tələbə əlavə olundu!");
            
            break;

        case 3:
            static void ShowAllStudents(List<Classroom> classrooms)
            {
                foreach (var c in classrooms)
                {
                    Console.WriteLine($"\n{c.Name} ({c.Type})");
                    foreach (var s in c.Students)
                        Console.WriteLine($"   {s}");
                }
            }
            break;

        case 4:
            static void ShowClassroomStudents(List<Classroom> classrooms)
            {
                Console.Write("Sinif ID: ");
                int id = int.Parse(Console.ReadLine());

                Classroom selected = classrooms.FirstOrDefault(c => c.ID == id); // yadda saxla
                if (selected == null) throw new ClassroomNotFoundException();

                Console.WriteLine($"\n{selected.Name} ({selected.Type}) tələbələri:");
                foreach (var s in selected.Students)
                    Console.WriteLine($"   {s}");
            }

            break;
        case 5:
            static void DeleteStudent(List<Classroom> classrooms)
            {
                Console.Write("Sinif ID: ");
                int classId = int.Parse(Console.ReadLine());
                Classroom selected = classrooms.FirstOrDefault(c => c.ID == classId); //yadda saxla

                if (selected == null) throw new ClassroomNotFoundException();

                Console.Write("Silinəcək tələbənin ID-si: ");
                int studentId = int.Parse(Console.ReadLine());

                selected.Delete(studentId);
                DataManager.Save(classrooms);
                Console.WriteLine(" Tələbə silindi!");
            }
            break;
        default:
            break;

            goto restart;
        }


    }
  
    }

