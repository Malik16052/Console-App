using System.ComponentModel.Design;
using System.Net.Http.Headers;
using static a.Helper;

namespace a;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public List<string> Students = new List<string>();
    
    public Student(int id, string name, string surname)
    {
        Id = id;
        foreach (string i in Students)
        {
            if (!char.IsUpper(i[0]) || i.Length < 3)
            {
                Console.WriteLine("Duzgun daxil edin");
            }

            else
                Name = name;
        }
        foreach (var item in Students)
        {
            if (item.IndexOf(' ') == -1)
            {
                Console.WriteLine("ifade tekdir");
                break;
            }
            else
            {
                int total = item.Count(x => x == ' ');
                Console.WriteLine($"total: {total}");
                string newList = item.Substring(0, item.IndexOf(' ') + total);
                if (newList.Length == Students[0].Length)
                {
                    Console.WriteLine("ifade 1 sozden ibaretdir");
                }
                else
                    Console.WriteLine("ifade cox sozden teskil olunmusdur");
            }
        }

        Name = name;

        Surname = surname;
    }

    
}
