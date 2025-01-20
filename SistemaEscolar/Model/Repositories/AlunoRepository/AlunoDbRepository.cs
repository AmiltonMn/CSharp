using System.Collections.Generic;
using DataBase;

namespace Model.Repository;

public class AlunoDbRepository : IRepository<Aluno>
{

    protected DBSqlSrv<Aluno> db;

    public AlunoDbRepository()
    {
        db = new DBSqlSrv<Aluno>(
            "CA-C-0064W\\SQLEXPRESS",
            "SistemaEscolar"
        );
    }
    public List<Aluno> All
        => db.All;

    public void Add(Aluno obj)
    {
        db.Save(obj);
    }
}