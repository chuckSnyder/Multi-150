using System.Collections;
using UnityEngine;
using System.Collections.Generic; // Required for Lists

public class RivalAI : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 10f;
    
    [Header("Targeting")]
    public List<string> ballTags = new List<string> { "BlueBall", "YellowBall", "RedBall", "OrangeBall" };

    [Header("Chaos Settings")]
    public float switchInterval = 3f; 
    private float switchTimer;

    [Header("Audio")]
    public AudioSource laughSource;

    private GameObject targetBall;

    void Start()
    {
        PickNewTarget();
    }

    void Update()
    {
        switchTimer -= Time.deltaTime;
        if (switchTimer <= 0 || targetBall == null)
        {
            PickNewTarget();
        }

        if (targetBall != null)
        {
            MoveTowardTarget();
        }
    }

    void PickNewTarget()
    {
        List<GameObject> allPossibleBalls = new List<GameObject>();
        foreach (string tag in ballTags)
        {
            GameObject[] ballsWithTag = GameObject.FindGameObjectsWithTag(tag);
            allPossibleBalls.AddRange(ballsWithTag);
        }

        if (allPossibleBalls.Count > 0)
        {
            targetBall = allPossibleBalls[Random.Range(0, allPossibleBalls.Count)];
            switchTimer = switchInterval + Random.Range(-1f, 1f);
            Debug.Log("AI shifted focus to: " + targetBall.name);
        }
    }

    void MoveTowardTarget()
    {
        Vector3 direction = (targetBall.transform.position - transform.position).normalized;
        Vector3 moveDir = new Vector3(direction.x, 0, direction.z);
        
        transform.position += moveDir * speed * Time.deltaTime;
        transform.LookAt(new Vector3(targetBall.transform.position.x, transform.position.y, targetBall.transform.position.z));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (ballTags.Contains(collision.gameObject.tag))
        {
            if (laughSource != null && !laughSource.isPlaying)
            {
                laughSource.pitch = Random.Range(0.7f, 1.4f);
                laughSource.Play();
            }
        }
    }
}