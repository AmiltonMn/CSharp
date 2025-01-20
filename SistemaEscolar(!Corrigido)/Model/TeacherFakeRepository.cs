namespace Model.Repository;

public class TeacherFakeRepository : Irepository<Teacher>
{
    List<Teacher> teachers = [];

    public TeacherFakeRepository()
    {
        Teacher teacher = new() {
            Name = "Jorge",
            Formation = "Doutor"
        };

        teachers.Add(teacher);
    }

    public List<Teacher> All => teachers;

    public void Add(Teacher obj) 
        => this.teachers.Add(obj);
}