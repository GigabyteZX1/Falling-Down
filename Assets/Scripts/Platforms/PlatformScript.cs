using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float move_speed = 2f;
    public float bound_Y = 6f;
    public float speed = 1f;

    public bool moving_Platform_left, moving_Platform_right, is_Breakable, is_Spike, is_Platform;

    private Animator anim;

    void Awake(){
        if(is_Breakable){
            anim = GetComponent<Animator>();
        }
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        Move();
    }

    void Move(){
        Vector2 temp = transform.position;
        temp.y += move_speed*Time.deltaTime;
        transform.position = temp;

        if(temp.y >= bound_Y){
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate(){
        Invoke("DeactivateGameObject",0.3f);
    }

    void DeactivateGameObject(){
        //SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "Player"){
            if(is_Spike){
                target.transform.position = new Vector2(1000f,1000f);
                //SoundManager.instance.GameOverSound();
                //GameManager.instance.RestartGame();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag == "Player"){
            if(is_Breakable){
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }

            if(is_Platform){
                SoundManager.instance.LandSound();
            }
        }
    }

    void OnCollisionStay2D(Collision2D target){
        if(target.gameObject.tag == "Player"){
            if(moving_Platform_left){
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-speed);
            }
            if(moving_Platform_right){
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(speed);
            }
        }
    }
}
