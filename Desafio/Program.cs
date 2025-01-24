using System.ComponentModel.Design;
using static System.Console;

var uni = new Universidade();

WriteLine("Os departamentos, em ordem alfabética, com o número de disciplinas.\n");

var query1 = 
    from D in uni.Departamentos
    join Di in uni.Disciplinas
    on D.Id equals Di.DepartamentoId
    select new { NomeDep = D.Nome, Di.DepartamentoId } into disciplinas
    group disciplinas by disciplinas.NomeDep into discGroup
    let countAlunos = discGroup.Count()
    orderby discGroup.Key
    select new { Nome = discGroup.Key, Qtd = countAlunos };

foreach (var item in query1)
{
    Console.WriteLine($"Nome do departamento: {item.Nome} {item.Qtd}");
}

WriteLine("\nListe os alunos e suas idades com seus respectivos professores.\n");

var query2 = 
    from A in uni.Alunos
    select new { 
        NomeAluno = A.Nome, 
        IdadeAluno = A.Idade, 
        NomeProfessor = (
            from AT in A.Matriculas
            join T in uni.Turmas on AT equals T.Id
            join P in uni.Professores
            on T.ProfessorId equals P.Id
            select P.Nome
        )};

foreach (var item in query2)
{
    Write($"Dados do aluno: {item.NomeAluno} - {item.IdadeAluno} - {{ ");

    var last = item.NomeProfessor.Last();
    foreach (var professor in item.NomeProfessor)
    {
        if (professor == last)
        {
            Write($"{professor} ");
        } else {
            Write($"{professor}, ");
        }
    }
    WriteLine("}");
}


WriteLine("\nListe os professores e seus salários com seus respectivos alunos.\n");

var query3 =
    from P in uni.Professores
    select new 
    {
        NomeProfessor = P.Nome,
        SalarioProfessor = P.Salario,
        Alunos = 
        (
            from T in uni.Turmas
            where T.ProfessorId == P.Id
            from A in uni.Alunos
            where A.Matriculas.Contains(T.Id)
            select A.Nome
        ).Distinct()
    };

foreach (var item in query3)
{
    Write($"{item.NomeProfessor} - {item.SalarioProfessor.ToString("C2")} - {{ ");

    var last = item.Alunos.Count();
    int countAlunos = 0;
    foreach (var aluno in item.Alunos)
    {
        countAlunos ++;

        if (countAlunos == last)
        {
            Write($"{aluno} ");   
        } else {
            Write($"{aluno}, ");
        }
    }

    WriteLine("}");
}

WriteLine("\nTop 5 Professores com mais alunos da universidade.\n");

var query4 =
    from P in uni.Professores
    select new 
    {
        NomeProfessor = P.Nome,
        Alunos = 
        (
            from T in uni.Turmas
            where T.ProfessorId == P.Id
            from A in uni.Alunos
            where A.Matriculas.Contains(T.Id)
            select new { NomeAluno = A.Nome, IdProfessor = P.Id }
        )
    } into SelectAlunos
    let countAlunos = SelectAlunos.Alunos.Count()
    orderby countAlunos descending
    select new
    {
        SelectAlunos.NomeProfessor,
        Count = countAlunos
    };

int count  = 0;

foreach (var item in query4.Take(5))
{
    WriteLine($"[{count + 1}] - {item.NomeProfessor} - {item.Count}");
    count ++;
}

WriteLine();

WriteLine(
    """
    Considerando que todo aluno custa 300 reais mais o salário dos seus professores
    divido entre seus colegas de classe. Liste os alunos e seus respectivos custos.
    """
);

WriteLine();

var query5 =
    from A in uni.Alunos
    from M in A.Matriculas
    join T in uni.Turmas on M equals T.Id
    join P in uni.Professores on T.ProfessorId equals P.Id
    group new { P.Id, P.Salario } by A.Nome into G
    select new 
    {
        NomeAluno = G.Key,
        Custo = 300 + (
            from P in G
            from A in uni.Alunos
            join T in uni.Turmas on P.Id equals T.ProfessorId
            where A.Matriculas.Contains(T.Id)
            group A by P into G2
            select G2.Key.Salario / G2.Count()
        ).Sum()
    } into item
    group item by item.NomeAluno into G
    select new { NomeAluno = G.Key, Custo = G.Sum(x => x.Custo) };

foreach (var item in query5)
{
    WriteLine($"{item.NomeAluno} - {item.Custo.ToString("C2")}");
}

ReadKey(true);

public record Professor(
    int Id,
    string Nome,
    int Idade,
    int DepartamentoId,
    decimal Salario
);

public record Departamento(
    int Id, 
    string Nome
);

public record Disciplina(
    int Id,
    string Nome,
    int DepartamentoId
);

public record Turma(
    int Id,
    int DisciplinaId,
    int ProfessorId,
    string Codigo
);

public record Aluno(
    int Id,
    string Nome,
    int Idade,
    List<int> Matriculas
);

public class Universidade
{
    public readonly IEnumerable<Departamento> Departamentos = [
        new(1, "DAMAT"), new(2, "DAFIS"), new(3, "DAINF"), new(4, "DAELN")
    ];

    public readonly IEnumerable<Disciplina> Disciplinas = [
        new(1, "Cálculo 1", 1), new(2, "Cálculo 2", 1), new(3, "Cálculo 3", 1), 
        new(4, "Física 1", 2), new(5, "Física 2", 2), new(6, "Física 3", 2), 
        new(7, "Técnicas de Programação 1", 3), new(8, "Técnicas de Programação 2", 3), 
        new(9, "Eletricidade", 4), new(10, "Oficinas de Integração", 4)
    ];

    public readonly IEnumerable<Professor> Professores = [
        new(1, "Fábio Dorini", 34, 1, 11_000),
        new(2, "Inácio", 45, 1, 14_000),
        new(3, "Roni", 38, 1, 10_000),
        new(4, "Leiza Dorini", 34, 3, 10_000),
        new(5, "Rafael Barreto", 29, 2, 15_000),
        new(6, "Bogdan Nassu", 32, 3, 17_000),
        new(7, "Bogado", 43, 3, 9_000),
        new(8, "Cezar Sanchez", 35, 4, 14_000),
        new(9, "Razera", 28, 4, 12_000)
    ];

    public readonly IEnumerable<Turma> Turmas = [
        new(1, 1, 1, "S71"), new(2, 2, 2, "S71"),
        new(3, 3, 3, "S71"), new(4, 4, 5, "S71"),
        new(5, 5, 5, "S71"), new(6, 6, 5, "S71"),
        new(7, 7, 6, "S71"), new(8, 8, 7, "S71"),
        new(9, 9, 9, "S71"), new(10, 10, 8, "S71"),
        new(11, 1, 2, "S73"), new(12, 7, 4, "S73")
    ];

    public readonly IEnumerable<Aluno> Alunos = [
        new(1, "Leonardo Trevisan Silio", 18, [ 3, 4, 8, 9 ]),
        new(2, "Bruna Pinheirinho", 18, [ 1, 6, 10 ]),
        new(3, "Alan Jun Onoda", 18, [ 2, 5, 7 ]),
        new(4, "Ian Douglas", 20, [ 3, 6, 10 ]),
        new(5, "Jordão Vyctor", 19, [ 3, 11, 12 ])
    ];
}