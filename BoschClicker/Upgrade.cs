public class Upgrade
{
    public string Name { get; set; } = "Upgrade";

    public string Description { get; set; } = "";

    public float Value { get; set; }

    public bool Acquired { get; set; } = false;

    public Upgrade(string name, string description, float value)
    {
        this.Name = name;
        this.Description = description;
        this.Value = value;
    }
}