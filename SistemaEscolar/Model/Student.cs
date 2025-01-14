using DataBase;

namespace models;

public class Student : DatabaseObject
{

    public string Name { get; set;}
    public int Age { get; set; }
    protected override void LoadFrom(string[] data)
    {
        this.Name = data[0];
        this.Age = int.Parse(data[1]);
    }

    protected override string[] SaveTo()
        => new string[]
        {
            this.Name,
            this.Age.ToString()
        };
}