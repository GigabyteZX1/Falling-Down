using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public float force = 600;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0){
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up*force);
        }
    }
}
