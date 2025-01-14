namespace models;

public class StudentFakeRepository : Irepository<Student>
{
    List<Student> students = [];

    public StudentFakeRepository()
    {
        students.Add(new ()
        {
            Name = "Irineu",
            Age = 20
        });
        students.Add(new ()
        {
            Name = "Amilton",
            Age = 20
        });
        students.Add(new ()
        {
            Name = "Fernando",
            Age = 20
        });
        students.Add(new ()
        {
            Name = "Juan",
            Age = 20
        });
        students.Add(new ()
        {
            Name = "Cristian",
            Age = 17
        });
        students.Add(new ()
        {
            Name = "Kauane",
            Age = 20
        });
    }
    public List<Student> All => students;

    public void Add(Student obj)
        => this.students.Add(obj);
}