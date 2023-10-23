using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{  
    public float jumpamount;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         collision.rigidbody.AddForce(Vector2.up * jumpamount, ForceMode2D.Impulse);
       
           anim.SetBool("IsTouch", true);
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
       anim.SetBool("IsTouch", false);
    }
}
