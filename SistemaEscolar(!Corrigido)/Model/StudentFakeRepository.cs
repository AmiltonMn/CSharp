using System;
namespace Model.Repository;

public class StudentFakeRepository : Irepository<Student>
{
    List<Student> students = [];

    public StudentFakeRepository()
    {
        Student student1 = new() {
            Name = "Amilton",
            Age = 20
        };

        Student student2 = new() {
            Name = "Fernando",
            Age = 20
        };

        Student student3 = new() {
            Name = "Juan",
            Age = 20
        };

        Student student4 = new() {
            Name = "Cristian",
            Age = 17
        };

        students.Add(student1);
        students.Add(student2);
        students.Add(student3);
        students.Add(student4);
    }
    public List<Student> All => students;

    public void Add(Student obj)
        => this.students.Add(obj);
}