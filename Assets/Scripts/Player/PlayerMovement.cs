using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed=1;
    // public float JumpForce = 1;
    
    private Rigidbody2D _rigidBody;
    
    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {

        Move();
        
        // if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidBody.velocity.y)<0.001){
        //     _rigidBody.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
        // }
    }

    void Move(){

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0)*Time.deltaTime*MovementSpeed;
        

    }

    public void PlatformMove(float x){

        _rigidBody.velocity = new Vector2(x,_rigidBody.velocity.y);
    }
}
