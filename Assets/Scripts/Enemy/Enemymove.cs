using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Enemymove : MonoBehaviour
{
    public float enemHealth;
    public float distDetection;
    public float speed;
    private Transform target;
    public GameObject blood;
    private AnimCamShake shake;
    public Slider enemHealthBar;
    public float damageShot;
    private Transform crop;
    private Collider2D playerSense;


    [Header("Audio")]
    public AudioClip[] zombienoises;
    private AudioClip groans;
    private AudioSource audioSource;


    void Awake()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<AnimCamShake>();
    }


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        crop = GameObject.FindGameObjectWithTag("Crop").GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Players").GetComponent<Transform>();
        enemHealth = 100;
        GameObject thePlayer = GameObject.FindGameObjectWithTag("Players");
        BasicMovement playerCol = thePlayer.GetComponent<BasicMovement>();
        playerSense = playerCol.playerCollider;
    }

    void OnTriggerEnter2D(Collider2D bullet)
    {
        if (bullet.gameObject.tag == "Bullet")
        {
            Debug.Log("ZombieShot!");
            enemHealth = enemHealth - damageShot;
            //Destroy(gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
            shake.CamShake();
        }

        if (enemHealth <= 0)
        {
            enemHealth = 0;
        }

        if (bullet.gameObject.tag == "Players")
        {
            int index = Random.Range(0, zombienoises.Length);
            groans = zombienoises[index];
            audioSource.clip = groans;
            audioSource.Play();
        }
    }



    void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.tag == "Players")
        {

            int index = Random.Range(0, zombienoises.Length);
            groans = zombienoises[index];
            audioSource.clip = groans;
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < distDetection && playerSense.enabled == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
          
        }
        else
        if (Vector2.Distance(transform.position, target.position) > distDetection)
        {
            transform.position = Vector2.MoveTowards(transform.position, crop.position, speed * Time.deltaTime);
        }
            }
            


    void Update()
    {
        enemHealthBar.value = enemHealth;


        if (enemHealth <= 0)
        {
            Destroy(gameObject);
        }


    }

}