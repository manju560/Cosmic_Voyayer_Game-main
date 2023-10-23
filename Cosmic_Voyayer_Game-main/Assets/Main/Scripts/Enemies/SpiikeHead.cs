using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiikeHead : MonoBehaviour
{
    public GameObject Player;
    [SerializeField]
    float speed = 1f;
    bool isTouched = false;
    Vector2 oldpos = Vector2.zero;
    [SerializeField]
    Vector2 playerpos = Vector2.zero;
    // Start is called before the first frame update
    private void Awake()
    {
        playerpos = Player.transform.position;
        oldpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //EnemyMove();
        FollowPlayer();


    }

    private void FollowPlayer()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, step);
    }

    private void EnemyMove()
    {
        float step = speed * Time.deltaTime;

        float Distanceorigin = Vector2.Distance(gameObject.transform.position, oldpos);
        float Distanceplayer = Vector2.Distance(gameObject.transform.position, playerpos);
        // Debug.Log(Distance);
        if (!isTouched)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerpos, step);
            if (Distanceplayer < .1f)
            {
                isTouched = true;
            }
        }
        else if (isTouched)
        {
            transform.position = Vector2.MoveTowards(transform.position, oldpos, step);
            if (Distanceorigin == 0f)
            {
                isTouched = false;
                playerpos = Player.transform.position;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            isTouched = true;
        }    
    }


}
