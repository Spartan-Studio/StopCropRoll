using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantInventoryContainer : MonoBehaviour
{
    public PlantInventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new PlantInventory();
        Debug.Log("Inventory: " + inventory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
