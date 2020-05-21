using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantInventoryContainer : MonoBehaviour
{
    public PlantInventory inventory;
    private Text invetoryText;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new PlantInventory();
        Debug.Log("Inventory: " + inventory);
        invetoryText = GameObject.FindGameObjectWithTag("InventoryText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        invetoryText.text = "Corn: " + inventory.getPlantAmount(inventory.selectedPlant);
    }
}
