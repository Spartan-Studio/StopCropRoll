using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantContainer : MonoBehaviour
{
    public Plant plantObject;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.enabled = false;
        spriteRenderer.transform.localScale = new Vector2(0.35f, 0.35f);
        spriteRenderer.transform.localPosition = new Vector2(0f, 0.02f);
    }

    private void OnEnable()
    {
        Debug.Log("PlantContainer enabled");
    }

    public void Plant(Plant plant)
    {
        Debug.Log("Plant()");
        this.plantObject = plant;
        spriteRenderer.sprite = this.plantObject.sprite;
    }
}
