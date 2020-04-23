using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantCrop : MonoBehaviour {

    public Text plantText;
    private bool selected;

    // Start is called before the first frame update
    void Start () {
        plantText = GameObject.FindGameObjectWithTag ("PlantCropText").GetComponent<Text>();
        plantText.enabled = false;
        this.selected = false;
        //transform.eulerAngles = new Vector3 (0, 0, 50);
    }

    // Update is called once per frame
    void Update () {
        if (this.selected && Input.GetKeyDown("e")){
            Debug.Log("E!");
        }
        }
    

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "Players") {
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
}