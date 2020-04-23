using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimerCountdown : MonoBehaviour
{

    float timeLeft = 11.0f;
    //public GameObject interPrefab;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Sunrise:  " + Mathf.Round(timeLeft);

        if (timeLeft <= 10.0f)
        {
            GetComponent<Text>().color = Color.red;
        }

        if (timeLeft <= 0.0f)
        {
            //GameObject interTimer = Instantiate<interPrefab>;
            Destroy(gameObject);
        }
    }



}
