using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public float JumpPower = 0.7f;
    Rigidbody2D rb;
    GuyMovement GuyMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GuyMovement = GetComponent<GuyMovement>();
    }

    public void PlayerJump()
    {
        if (GuyMovement.isGrounded())
        {
            rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
           
        }
    }
}
