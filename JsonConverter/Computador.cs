using System.Diagnostics.Contracts;

public class Computador
{
    public string CPU { get; set; }

    public string GPU { get; set; }

    public string PlacaMae { get; set; }

    public List<RAM> RAM { get; set; }

    public int HD { get; set; }
}