using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using DataBase;

namespace Model;

public class StudentClass : DatabaseObject
{

    public string Name { get; set; } = "Sala";

    public List<Student> Students { get; set; }
    public Teacher Teacher { get; set; }

    protected override void LoadFrom(string[] data)
    {
        int limit = data.Count();

        this.Name = data[0];
        this.Teacher.Name = data[1];
        this.Teacher.Formation = data[2];

        for (int i = 3; i < limit; i += 2)
        {
            Student student = new();

            student.Name = data[i];
            student.Age = int.Parse(data[i + 1]);

            Students.Add(student);
        }
    }

    protected override string[] SaveTo()
    {
        List<string> data = [];

        data.Add(Name);

        data.Add(Teacher.Name);
        data.Add(Teacher.Formation);
        
        for (int i = 0; i < Students.Count; i++)
        {
            data.Add(Students[i].Name);
        }

        for (int i = 0; i < Students.Count; i++)
        {
            data.Add(Students[i].Age.ToString());
        }

        return data.ToArray();
    }
}