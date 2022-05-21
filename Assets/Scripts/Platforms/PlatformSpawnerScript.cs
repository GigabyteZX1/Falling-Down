using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatformPrefab;
    public GameObject breakablePlatformPrefab;

    public float Spawn_timer;
    private float current_Spawn_Timer;

    private int platform_Spawn_Count;

    public float min_x = -2.2f, max_x = 2.2f;


    void Start()
    {
        current_Spawn_Timer = Spawn_timer;
    }

    
    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms(){
        current_Spawn_Timer += Time.deltaTime;

        if(current_Spawn_Timer >= Spawn_timer){
            platform_Spawn_Count++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(min_x,max_x);

            GameObject newPlatform = null;

            if(platform_Spawn_Count <2){
                newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);

            } else if(platform_Spawn_Count == 2){
                if(Random.Range(0,2)>0){
                    newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);

                } else {
                    newPlatform = Instantiate(movingPlatformPrefab[Random.Range(0,movingPlatformPrefab.Length)],temp,Quaternion.identity);
                }
            } else if(platform_Spawn_Count ==3){
                if(Random.Range(0,2)>0){
                    newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);

                } else {
                    newPlatform = Instantiate(spikePlatformPrefab,temp,Quaternion.identity);
                }
            } else if(platform_Spawn_Count == 4){
                if(Random.Range(0,2)>0){
                    newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);

                } else {
                    newPlatform = Instantiate(breakablePlatformPrefab,temp,Quaternion.identity);
                }
            platform_Spawn_Count = 0;
            }

        if(newPlatform)
        newPlatform.transform.parent = transform;
        current_Spawn_Timer = 0;
        }

    }
}
