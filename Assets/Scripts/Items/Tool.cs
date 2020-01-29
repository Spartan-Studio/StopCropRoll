public class Tool : Item
{
    public float cropMultiplier { get; set; }

    public float seedMultiplier { get; set; }

    public Tool(string name, int ammo, int capacity, float cropMultipler, float seedMultiplier)
    {
        this.name = name;
        this.breakable = false;
        this.durability = ammo;
        this.maxDurability = capacity;
        this.cropMultiplier = cropMultiplier;
        this.seedMultiplier = seedMultiplier;
    }
}
