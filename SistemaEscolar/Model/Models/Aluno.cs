using System.Data;
using DataBase;

namespace Model;

public class Aluno : DataBaseObject
{
    public string id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string idSala { get; set; }

    public Aluno() => id = GetNewId;

    protected override void LoadFrom(string[] data)
    {
        this.id = data[0];
        this.Nome = data[1];
        this.Idade = int.Parse(data[2]);
        this.idSala = data[3];
    }

    protected override string[] SaveTo()
        => [
            this.id,
            this.Nome,
            this.Idade.ToString(),
            this.idSala
        ];

    protected override void LoadFromSqlRow(DataRow data)
    {
        this.id = data[0].ToString();
        this.Nome = data[1].ToString();
        this.Idade = int.Parse(data[2].ToString());
        this.idSala = data[3].ToString();
    }

    protected override string SaveToSql()
        => $"INSERT INTO [Aluno] VALUES ('{id}', '{Nome}', {Idade}, '{idSala}')";
}