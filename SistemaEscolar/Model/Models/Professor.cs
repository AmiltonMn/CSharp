using System.Collections.Generic;
using System.Data;
using DataBase;

namespace Model;

public class Professor : DataBaseObject
{
    public string id { get; private set; }
    public string Nome { get; set; }
    public string Formacao { get; set; }

    public Professor() => id = GetNewId;

    protected override void LoadFrom(string[] data)
    {
        this.id = data[0];
        this.Nome = data[1];
        this.Formacao = data[2];
    }

    protected override string[] SaveTo()
        => [
            this.id,
            this.Nome,
            this.Formacao
        ];

    public override string ToString()
        => $"""
            ID: {id}
            Nome: {Nome }
            Formação: {Formacao}
        """;

    protected override void LoadFromSqlRow(DataRow data)
    {
        this.id = data[0].ToString();
        this.Nome = data[1].ToString();
        this.Formacao = data[2].ToString();
    }

    protected override string SaveToSql()
        => $"INSERT INTO [Professor] VALUES ('{id}', '{Nome}', '{Formacao}')";

}