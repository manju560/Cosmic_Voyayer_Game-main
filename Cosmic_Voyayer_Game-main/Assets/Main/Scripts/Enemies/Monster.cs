using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Movement inputs")]
    [SerializeField]
    float movespeed = 2f;
   [Header("References")]
    Rigidbody2D rb;  
    public Animator anim;
    public SpriteRenderer sprite;

    
    [SerializeField]
    float distance = 1f;

    [Header("boolean")]
    [SerializeField]
    bool ishit = false;
    bool israycasted = true;
    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move();
       
    }

    private void AnimationMovement(float move)
    {
        if (rb.velocity.x > 1f ) {
            // "isAttacking" isdead isWalking
            anim.SetBool("isWalking", true);
            sprite.flipX = false;
        }

        else if(rb.velocity.x < -1f)
        {
            sprite.flipX = true;
        }
    }

    private void move()
    {
        Raycast();
        Vector2 movedir = Vector2.right;
        rb.velocity = movedir * movespeed;
       AnimationMovement(movedir.x);
    }

    private void Raycast()
    {
   /*     RaycastHit2D hitleft = Physics2D.Raycast(transform.position, Vector2.left, distance);
        RaycastHit2D hitright = Physics2D.Raycast(transform.position, Vector2.right, distance);
        RaycastHit2D hitup = Physics2D.Raycast(transform.position,Vector2.up, distance);
       
        if (hitleft.collider != null)
        {
            movespeed = 3f;
        }
        else if (hitright.collider != null)
        {
            movespeed *= -1;
        }

        else if(hitup.collider != null)
        {
            ishit = true;
            anim.SetTrigger("Death");
            movespeed = 0;
        }*/


        Vector2 raydir = israycasted ? Vector2.right : -Vector2.right;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, raydir,distance);
        RaycastHit2D hitup = Physics2D.Raycast(transform.position, Vector2.up, distance);

      
        if (hit.collider != null)
        {
            israycasted = !israycasted;
            if(hit.normal.x > 1f)
            {
                movespeed = 3f;             
            }
            else
            {
                movespeed *= -1f;             
            }
            
        }
        if(hitup.collider != null)
        {
           
            anim.SetTrigger("Death");
            movespeed = 0;
        }
    }
}
