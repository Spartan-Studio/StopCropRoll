using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantCrop : MonoBehaviour {

    public Text plantText;
    private bool selected;
    private PlantInventory inventory;
    public PlantContainer plantContainer;

    // Start is called before the first frame update
    void Start () {
        plantText = GameObject.FindGameObjectWithTag ("PlantCropText").GetComponent<Text>();
        plantText.enabled = false;
        this.selected = false;
        plantContainer = GetComponentInChildren<PlantContainer>();
        //transform.eulerAngles = new Vector3 (0, 0, 50);
    }

    // Update is called once per frame
    void Update () {
        if (this.selected){
            if (Input.GetKeyDown("e")) {
                Debug.Log("inventory amount: " + inventory.getPlantAmount(inventory.selectedPlant));
                if(inventory.getPlantAmount(inventory.selectedPlant) > 0)
                {
                    plantCrop(inventory.selectedPlant);
                    plantText.text = Const.harvestText;
                }
                else
                {
                    plantText.text = Const.notEnoughSeeds;
                }
            }
            else if (Input.GetKeyDown("q"))
            {
                harvestCrop();
                plantText.text = Const.plantText;
            }
            } 
        }
    

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Players") {
            this.inventory = col.gameObject.GetComponent<PlantInventoryContainer>().inventory;
            if (plantContainer.hasPlant())
            {
                plantText.text = Const.harvestText;
            }
            else
            {
                plantText.text = Const.plantText;
            }
            plantText.enabled = true;
            this.selected = true;
        }
    }

    void OnTriggerExit2D (Collider2D col) {
        if (col.gameObject.tag == "Players") {
            plantText.enabled = false;
            this.selected = false;
            inventory = null;
        }
    }

    private void plantCrop(Plant plant)
    {
        plantContainer.Plant(plant);
        inventory.removePlantAmount(plant, 1);
        Debug.Log("Planted crop: " + plant.ToString());
    }

    private Plant harvestCrop()
    {
        Plant plant = plantContainer.Harvest();
        inventory.addPlantAmount(plant, 2);
        return plant;
    }
}