using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour {

    public Transform target;
    public float speed = 2f;
    private float minDistance = 2f;
    private float range;
    private Animator anima;

    void Start()
    {
        target = GameObject.FindWithTag("Players").transform;
        anima = GetComponent<Animator>();
    }


    void FixedUpdate() {
        range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (speed > 0)
            {
                anima.SetBool("EnemyRun", true);
            }
        else
        {
                anima.SetBool("EnemyRun", false);
            }
        }
    }
