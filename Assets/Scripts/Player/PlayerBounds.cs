using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float min_x = -2.6f, max_x = 2.6f, min_y = -5.6f;
    private bool outOfBounds;

    
    void Update()
    {
        CheckBounds();
    }

    void CheckBounds(){
        Vector2 temp = transform.position;

        if(temp.x>max_x)
        temp.x = max_x;
        if(temp.x <min_x)
        temp.x = min_x;

        transform.position = temp;

        if(temp.y<= min_y){
            if(!outOfBounds){
                outOfBounds = true;
                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
            }

        }
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "Spike"){
            transform.position = new Vector2(1000f,1000f);
            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();
        }
    }
}
