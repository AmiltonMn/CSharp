
namespace Model.Repository;

public class StudentClassFakeRepository : Irepository<StudentClass>
{

    List<StudentClass> classes = [];

    public StudentClassFakeRepository()
    {
        Student student1 = new (){
            Name = "Amilton",
            Age = 20
        };

        Student student2 = new (){
            Name = "Kauane",
            Age = 20
        };

        Student student3 = new (){
            Name = "Cristian",
            Age = 17
        };

        Student student4 = new (){
            Name = "Juan",
            Age = 20
        };

        Student student5 = new (){
            Name = "Fernando",
            Age = 20
        };

        Teacher teacher = new (){
            Name = "Jorge",
            Formation = "Doutor"
        };

        classes.Add(new () {
            Students = [
                student1,
                student2,
                student3,
                student4,
                student5
            ],
            Teacher = teacher
        });
    }
    public List<StudentClass> All => classes;

    public void Add(StudentClass obj)
        => this.classes.Add(obj);
}