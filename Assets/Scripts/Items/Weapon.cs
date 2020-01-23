public class Weapon : Item
{
    public float damage { get; set; }

    public Weapon(string name, int ammo, int capacity, float damage)
    {
        this.name = name;
        this.breakable = false;
        this.durability = ammo;
        this.maxDurability = capacity;
        this.damage = damage;
    }
}
