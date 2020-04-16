using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordDamage : MonoBehaviour {

    public GameObject self;
    public GameObject blood;
    private AnimCamShake shake;

    void Awake ()
    {
        //reference camshake here
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<AnimCamShake>();
    }

   


    void OnTriggerEnter2D(Collider2D sword)
    {
        if (sword.gameObject.tag == "Sword")
        {
            shake.CamShake();
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(self);
            Debug.Log("Ow!");
            //make camera shake when enemy dies
        }
    }
}

