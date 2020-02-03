public abstract class Plant
{
    public string name { get; set; }

    public PlantType plantType;
    public int buyValue { get; set; }

    public int sellValue { get; set; }

    public float growthRate { get; set; }

    public float targetValue { get; set; }

}

public enum PlantType
{
    Health,
    Buff,
    Sellable
}