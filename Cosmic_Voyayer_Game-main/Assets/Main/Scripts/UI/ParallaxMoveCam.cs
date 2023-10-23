using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMoveCam : MonoBehaviour
{
    public Camera Camera;
    float length, starpos;
    float distance;
    [SerializeField]
    SpriteRenderer sprite;
    [SerializeField]
    float speed;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        starpos = transform.position.x;
       length =sprite.bounds.size.x;

    }

    // Update is called once per frame
    void Update()
    {
        distance = Camera.transform.position.x + speed;
        Vector2 newpos = new Vector2(distance + starpos, transform.position.y);
        transform.position = newpos;
    }
}
