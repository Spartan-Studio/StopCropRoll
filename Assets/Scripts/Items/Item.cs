public abstract class Item
{
    public string name { get; set; }
    
    public int durability { get; set; }

    public int maxDurability { get; set; }

    public bool breakable { get; set; }
}
