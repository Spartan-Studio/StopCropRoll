
using System.Collections.Generic;
using UnityEngine;

public class PlantInventory
{
    private Dictionary<Plant, int> inventory;
    public Plant selectedPlant;

    public PlantInventory()
    {
        inventory = new Dictionary<Plant, int>();
        selectedPlant = Resources.Load<Plant>("Corn");
        addPlantAmount(selectedPlant, 2);
    }

    public void clearInventory()
    {
        inventory = new Dictionary<Plant, int>();
    }

    public int getPlantAmount(Plant plant)
    {
        Debug.Log("inventory[corn] = " + inventory[plant]);
        if(!inventory.ContainsKey(plant))
        {
            return 0;
        }
        return inventory[plant];
    }

    public void removePlantAmount(Plant plant, int amount)
    {
        inventory[plant] -= amount;
        Debug.Log("Plant Amount: " + inventory[plant]);
    }

    public void addPlantAmount(Plant plant, int amount)
    {
        if(!inventory.ContainsKey(plant))
        {
            Debug.Log("does not contain key");
            inventory[plant] = 0;
        }
        inventory[plant] += amount;
        Debug.Log("Plant Amount: " + inventory[plant]);
    }
}
