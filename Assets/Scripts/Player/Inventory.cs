
using System.Collections.Generic;

public class Inventory
{
    private IDictionary<string, int> inventory;

    public Inventory()
    {
        inventory = new Dictionary<string, int>();
    }

    public int getInventoryAmount(string plantName)
    {
        return inventory[plantName];
    }

    public void addInventortAmount(string plantName, int amount)
    {
        inventory[plantName] += amount;
    }
}
