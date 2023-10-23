using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float speed = 2;
    [SerializeField]
    GameObject[] Waypoints;
    int currentwaypoint;


    private void Update()
    {
        if (Vector2.Distance(Waypoints[currentwaypoint].transform.position,transform.position) < .1f)
        {
            currentwaypoint++;
            if(currentwaypoint >= Waypoints.Length)
            {
                currentwaypoint = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, Waypoints[currentwaypoint].transform.position,Time.deltaTime *speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        collision.gameObject.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            collision.gameObject.transform.SetParent(null);
    }
}
