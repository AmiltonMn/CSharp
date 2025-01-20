using System.Collections.Generic;
using System.Data.Common;
using DataBase;

namespace Model.Repository;

public class ProfessorDbRepository : IRepository<Professor>
{
    protected DBSqlSrv<Professor> db;

    public ProfessorDbRepository()
    {
        db = new DBSqlSrv<Professor>(
            "CA-C-0064W\\SQLEXPRESS",
            "SistemaEscolar"
        );
    }

    public List<Professor> All
        => db.All;

    public void Add(Professor obj)
    {
        db.Save(obj);
    }
}