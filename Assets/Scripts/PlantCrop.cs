using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantCrop : MonoBehaviour {

    public Text plantText;
    private bool selected; 
    public PlantContainer plantContainer;

    // Start is called before the first frame update
    void Start () {
        plantText = GameObject.FindGameObjectWithTag ("PlantCropText").GetComponent<Text>();
        plantText.enabled = false;
        this.selected = false;
        plantContainer = GetComponentInChildren<PlantContainer>();
        Debug.Log("plantContainer is assigned");
        Debug.Log("plantContainer is disabled");
        //transform.eulerAngles = new Vector3 (0, 0, 50);
    }

    // Update is called once per frame
    void Update () {
        if (this.selected){
            if (Input.GetKeyDown("e")) {
                Debug.Log("E!");
                plantCrop(Resources.Load<Plant>("Corn"));
                plantText.text = Const.harvestText;
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
        }
    }

    private void plantCrop(Plant plant)
    {
        plantContainer.Plant(plant);
        Debug.Log("Planted crop: " + plant.ToString());
    }

    private Plant harvestCrop()
    {
        return plantContainer.Harvest();
    }
}