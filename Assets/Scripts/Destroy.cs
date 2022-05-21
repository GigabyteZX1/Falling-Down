using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject player;
    public GameObject platform;
    public GameObject normalPlat;
    private GameObject newPlat;
    public float y_offset;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if(collision.gameObject.name.StartsWith("NormalPlat"))
        {
            if(Random.Range(1,7) == 1){
                Destroy(collision.gameObject);
                Instantiate(platform, new Vector2(Random.Range(-5.5f,5.5f),player.transform.position.y + (y_offset+Random.Range(0.2f,1f))),Quaternion.identity);
            } else{
                collision.gameObject.transform.position = new Vector2(Random.Range(-5.5f,5.5f),player.transform.position.y + (y_offset+Random.Range(0.2f,1f)));
            }
        } else if(collision.gameObject.name.StartsWith("BouncyPlat"))
        {
            if(Random.Range(1,7) == 1){
                collision.gameObject.transform.position = new Vector2(Random.Range(-5.5f,5.5f),player.transform.position.y + (y_offset+Random.Range(0.2f,1f)));
            } else{
                
                Destroy(collision.gameObject);
                Instantiate(normalPlat, new Vector2(Random.Range(-5.5f,5.5f),player.transform.position.y + (y_offset+Random.Range(0.2f,1f))),Quaternion.identity);
            }
        }
    }
}
