using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class GuyMovement : MonoBehaviour
{
    [Header("Player Inputs")]
    public float PlayerMovespeed;        //Determines the speed of the Player 
    public float _score;       // Stores the amount of Cherries
    private float move;
 
    [Header("Dev Mode")]
    public float movedir;

    [Header("References")]
    public GameManager GameManager;
    public LayerMask JumpGround;
    public AnimationManager AnimationManager;
    Rigidbody2D rb;     //The Movement Control of Player
    Animator animator;  // Controls the Animations
    SpriteRenderer sprite;   // Used for Flipping the spirte
    BoxCollider2D boxcoll;   // Used for Checking Ground                           

    [Header("UI")]
    public Text ScoreText;  // Displays the amount of Cherries



    private enum MovementDirections { idle, run, jump, fall }
  

    private void Awake()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }
    }
    private void Start()
    {
        //Access the rigidbody component
        rb = GetComponent<Rigidbody2D>();

        // Access the Animator component from a other gameobject
        animator = GameObject.Find("Body").GetComponent<Animator>();

        //Access the Sprite component from a other gameobject
        sprite = GameObject.Find("Body").GetComponent<SpriteRenderer>();

        //Access the BoxCollider component
        boxcoll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        movedir = Input.GetAxis("Horizontal");
        Move(movedir);
        //  UpdateScore();
    }

    public void Move(float value)
    {
        //The Movement of 'x-axis' Input is Obtained
          move = Input.GetAxis("Horizontal");
       
        if (value == 0)
        {
         move = 0;
        }
         move = +value;
        
         rb.velocity = new Vector2(move * PlayerMovespeed, rb.velocity.y);            
        UpdateAnimations(move);
       
    }

    //Scores get updated everytime when player collects the cherry
    private void UpdateScore()
    {
       ScoreText.text =  _score.ToString();
    }

    //The animations such as idle, run, jump & fall
    public void UpdateAnimations(float move)
    {
        MovementDirections state = MovementDirections.idle;
        switch (move)
        {
            case > 0:
                state = MovementDirections.run;
                sprite.flipX = false;
                break;
            case < 0:
                state = MovementDirections.run;
                sprite.flipX = true;
                break;
            default:
                state = MovementDirections.idle;
                break;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementDirections.jump;
        }
        else if(rb.velocity.y < -1f)
        {
            state = MovementDirections.fall;
        }

        animator.SetInteger("Value", (int)state);
    }
    
    //checking if the player is ground
    public bool isGrounded()
    {
        return Physics2D.BoxCast(boxcoll.bounds.center, boxcoll.bounds.size, 0f, Vector2.down,.1f,JumpGround);
    }

    //The player collects the collectibles such as cherries and other stuff for points
    private void OnTriggerEnter2D(Collider2D collision)
    {
       int sceneno = SceneManager.GetActiveScene().buildIndex;
        if (collision.tag == "Colletibles")
        {
            Destroy(collision.gameObject);
            _score++;
           
        }
        if(collision.tag == "Goal")
        {
            StartCoroutine(LevelTransition());
           
        }
    }

    //If player collides with enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Water")
            StartCoroutine(PlayerDeath());     
    }

    IEnumerator PlayerDeath()
    {
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(1f);
        //Gameover menu
        rb.bodyType = RigidbodyType2D.Static;
       GameManager.LoadsceneTransition();
    }

    IEnumerator LevelTransition()
    {
        AnimationManager.Scene();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
