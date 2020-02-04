
using System.Collections.Generic;

public class PlantInventory
{
    private IDictionary<string, int> inventory;

    public PlantInventory()
    {
        inventory = new Dictionary<string, int>();
    }

    public int getPlantAmount(string plantName)
    {
        return inventory[plantName];
    }

    public void addPlantAmount(string plantName, int amount)
    {
        inventory[plantName] += amount;
    }
}
