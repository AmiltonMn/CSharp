using DataBase;
using Model;
using Model.Repository;
using static System.Console;

Irepository<Student> studentRepo = null;
Irepository<Teacher> teacherRepo = null;
Irepository<StudentClass> classRepo = null;

List<Student> students = [];

Student newStudent = new(){
    Name = "Amilton",
    Age = 20
};

students.Add(newStudent);

bool run = true;

var banquinho = DB<Student>.App;

banquinho.Save(students);

Thread.Sleep(3000);

var storagedStudents = banquinho.All;

WriteLine(storagedStudents);
WriteLine(storagedStudents[0].Name);

Thread.Sleep(1000);

while (run)
{
    try
    {
        Clear();

        WriteLine("""
            [1] - Registrar novo professor
            [2] - Registrar novo aluno
            [3] - Registrar nova sala
            [4] - Ver todos os professores
            [5] - Ver todos os estudantes
            [6] - Ver todas as salas
            [7] - Sair
        """);
        
        int option = int.Parse(ReadLine());

        switch (option)
    {
        case 1:
            Clear();

            Teacher teacher = new();
            
            WriteLine("Insira o nome do professor: ");
            teacher.Name = ReadLine();

            WriteLine("Insira a formação do professor: ");
            teacher.Formation = ReadLine();

            teacherRepo.Add(teacher);

            break;

        case 2:
            Clear();

            Student student = new();
            
            WriteLine("Insira o nome do aluno: ");
            student.Name = ReadLine();

            WriteLine("Insira a idade do aluno: ");
            student.Age = int.Parse(ReadLine());

            studentRepo.Add(student);

            break;
        
        case 3:
            Clear();

            bool addPersonsToClass = true;

            List<Student> choosenStudents = [];
            List<Student> availableStudents = [];
            List<Teacher> storagedTeachers = teacherRepo.All;

            StudentClass newClass = new();

            WriteLine("Insira o nome da sala");

            newClass.Name = ReadLine();

            while (addPersonsToClass)
            {
                Write("========================================\n");
                Write("|   Digite 1 para adicionar Aluno      |\n");
                Write("|   Digite 2 para vincular Professor   |\n");
                Write("|   Digite 3 para concluir             |\n");
                Write("========================================\n");
                
                int addOption = int.Parse(ReadLine());

                switch (addOption)
                {
                    case 3:
                        addPersonsToClass = false;
                        break;

                    case 1:

                        while (true)
                        {    
                            Clear();

                            WriteLine("==========================================");
                            WriteLine("|                 Alunos                 |");
                            WriteLine("==========================================");

                            for (int i = 0; i < storagedStudents.Count; i++)
                            {
                                if (!choosenStudents.Contains(storagedStudents[i]))
                                {
                                    WriteLine($"        {storagedStudents[i].Name} - {storagedStudents[i].Age}      ");
                                }
                            }

                            WriteLine("==========================================");

                            WriteLine("==        Escolha o ID do Aluno         ==");

                            WriteLine("==        Ou Aperte 0 para sair         ==");

                            WriteLine("==========================================");

                            int choosenStudent = int.Parse(ReadLine());

                            if (choosenStudent == 0)
                            {
                                break;
                            } 
                            else if (choosenStudent < 0 || choosenStudent > storagedStudents.Count)
                            {
                                WriteLine($"Por favor insira um número maior que zero e que não ultrapasse {storagedStudents.Count}");
                            } else {

                                availableStudents.Clear();

                                choosenStudents.Add(storagedStudents[choosenStudent]);

                                for (int i = 0; i < storagedStudents.Count; i++)
                                {
                                    if (!choosenStudents.Contains(storagedStudents[i]))
                                    {
                                        availableStudents.Add(storagedStudents[i]);
                                    }
                                }
                            }
                        }

                        

                        break;

                    case 2:

                        Clear();

                        if (newClass.Teacher != null)
                        {
                            WriteLine("Essa turma já possui um professor vinculado a ela!");
                        }

                        WriteLine("==========================================");
                        WriteLine("|                Professor               |");
                        WriteLine("==========================================");

                        foreach (var item in storagedTeachers)
                        {
                            WriteLine($"              {item.Name} - {item.Formation}            ");
                        }

                        WriteLine("==========================================\n");

                        WriteLine("Digite o ID do professor que você gostaria de vincular");

                        int id = int.Parse(ReadLine());

                        if (id > storagedTeachers.Count || id < 0)
                        {
                            WriteLine("Insira um valor válido!");
                        } else {
                            newClass.Teacher = storagedTeachers[id];
                        }

                        break;

                    default:
                        break;
                }
            }

            break;
            
        case 4:
            var profs = teacherRepo.All;
            foreach (var prof in profs)
            {
                WriteLine($"""
                    {prof.Formation} - {prof.Name}
                """);
            }

            break;

        case 5:
            // var students = studentRepo.All;

            foreach (var storedStudent in students)
            {
                WriteLine($"""
                    {storedStudent.Name} - {storedStudent.Age} 
                """);
            }

            break;

        case 6:
            var classes = classRepo.All;

            Clear();

            for (int i = 0; i < classes.Count; i++)
            {
                WriteLine($"{classes[i].Name} Alunos");

                WriteLine("_______________________\n");

                foreach (var storedStudent in classes[i].Students)
                {
                    WriteLine($"""
                        {storedStudent.Name} - {storedStudent.Age}
                    """);
                }

                WriteLine("_______________________\n");

                WriteLine($"{classes[i].Name} Professor");

                WriteLine($"""
                    {classes[i].Teacher.Name} - {classes[i].Teacher.Formation}
                """);
            }

            try
            {
                int classOption = int.Parse(ReadLine());
            }
            catch (System.Exception)
            {
                
                throw;
            }

            break;

        case 7:
            WriteLine("Exiting the system!");
            run = false;

            break;
            
        
        default:
            break;
    }
    }
    catch (System.Exception)
    {
        WriteLine("Erro na aplicação, por favor consulte a TI");
        throw;
    }

    WriteLine("\nPressione qualquer tecla para continuar...");

    ReadKey(true);
}