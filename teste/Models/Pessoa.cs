using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Model;

public class Pessoa
{
    public bool podePegarName = false;
    public string Name { get; set; } // ? Caso não for colocar default, não precisa colocar ";" depois do { get; set; }

    public Pessoa( string name )
    {
        this.Name = name;
    }

    public List<string> docs { get; private set; } = ["000", "111"];
}