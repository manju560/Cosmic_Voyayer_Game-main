using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipe : MonoBehaviour
{
    private Vector2 startpos;
    private int pixeldist = 20;
    [SerializeField]
    private bool fingerdown = false;
    GuyMovement GuyMovement;
    private void Start()
    {
        GuyMovement = GameObject.Find("Player").GetComponent<GuyMovement>();
    }
    private void Update()
    {
        if(Time.timeScale>= 1)
        SwipeTouchInput();
    }

    private void SwipeTouchInput()
    {
        if (fingerdown == false && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            startpos = Input.mousePosition;
            fingerdown = true;
        }
        if (fingerdown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            fingerdown = false;
        }

        if (fingerdown)
        {

            if (Input.touches[0].position.x >= startpos.x + pixeldist)
            {
               
                GuyMovement.Move(1);

            }
            else if (Input.touches[0].position.x <= startpos.x - pixeldist)
            {
                
                GuyMovement.Move(-1);
            }

            
        }
        else
        {
        //    GuyMovement.Move(0);
        }

    }    
}
