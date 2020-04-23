using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]
public class Plant : ScriptableObject
{
    public new string name;

    public PlantType plantType;

    public int buyValue;

    public int sellValue;

    public float growthRate;

    public float targetValue;

    public float hitpoints;

    public Sprite sprite;

}

public enum PlantType
{
    HEALTH, BUFF, SELLABLE
}
