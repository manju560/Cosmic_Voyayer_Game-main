using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawCutter : MonoBehaviour
{
  
    private float elapsedTime;
    private float desiredtime = 5f;

    private Vector3[] pos = new Vector3[2];

    [SerializeField]
    float Speed;
    private int curpos;

    [SerializeField]
    float PosX, PosY;
    private void Start()
    {
        pos[0] = transform.position + new Vector3(PosX, PosY, 0);
        pos[1] = transform.position + new Vector3(-PosX, -PosY, 0);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        float percentagecomplete = elapsedTime / desiredtime;

        if (Vector3.Distance(pos[curpos], transform.position) <= .1f)
        {
            curpos++;
            if (curpos >= pos.Length)
            {
                curpos = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, pos[curpos], Speed);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(collision.gameObject);
    }
}
