using DataBase;

namespace Model;

public class Teacher : DatabaseObject
{
    public string Name { get; set; }

    public string Formation { get; set; }

    protected override void LoadFrom(string[] data)
    {
        this.Name = data[0];
        this.Formation = data[1];
    }

    protected override string[] SaveTo()
        => [
            this.Name,
            this.Formation
        ];
}