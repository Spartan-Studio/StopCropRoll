using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayerDie : MonoBehaviour {

    public AnimCamShake shake;
    public GameObject blood;
    public GameObject self;
   


    void Awake()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<AnimCamShake>();
    }

    void OnCollisionEnter2D(Collision2D player) {
		if (player.gameObject.tag == "Player")
        {
            shake.CamShake();
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(self);
        }
	}
}
