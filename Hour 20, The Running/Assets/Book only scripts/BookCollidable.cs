using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollidable : MonoBehaviour
{
    public float timeAmount = 1.5f; 
    public float moveSpeed = 10f; 
    public BookGameManager manager; 

    void Start()
    {
        if (manager == null)
        {
            manager = FindObjectOfType<BookGameManager>();
        }
    }

    void Update()
    {
        transform.Translate(0f, 0f, -moveSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("debug: Something hit me! Name: " + other.gameObject.name + " | Tag: " + other.tag);

        if (other.CompareTag("bookplayer"))
        {
            manager.AdjustTime(timeAmount);
            Destroy(gameObject);
        }
    }
}