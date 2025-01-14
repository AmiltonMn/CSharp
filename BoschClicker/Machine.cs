public class Machine
{
    public int Generation { get; set; }

    public float Multiplier { get; set; }

    public float Value { get; set;}

    public float CPS { get; set; }

    public string Name { get; set; } = "Machine";

    public double Acquired { get; set; } = 0;

    public string Description { get; set; }

    public Machine(string name, string description, float value)
    {
        this.Name = name;
        this.Description = description;
        this.Value = value;
    }
}