using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawner : MonoBehaviour
{ 

    
    public float spawncycle = 2f; 
    public GameObject PowerupPrefab;
    public GameObject ObstaclePrefab;

    BookGameManager manager;
    float elapsedTime;
    bool spawnPowerup = true;

    void Start()
    {
        
        manager = GetComponent<BookGameManager>();
    }

    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime > spawncycle)
        {
            
            GameObject temp;
            
            if (spawnPowerup)
                temp = Instantiate(PowerupPrefab) as GameObject;
            else
                temp = Instantiate(ObstaclePrefab) as GameObject;
                
            Vector3 position = temp.transform.position;
            position.x = Random.Range(-3f, 3f);
            
            
            temp.transform.position = position;
            
            
            BookCollidable col = temp.GetComponent<BookCollidable>();
            
            col.manager = manager;
            elapsedTime = 0;
            
            
            spawnPowerup = !spawnPowerup;
        } 
    } 
} 