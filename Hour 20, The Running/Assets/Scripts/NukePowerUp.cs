using UnityEngine;

public class NukePowerUp : MonoBehaviour
{
    [Header("Movement")]
    public float rotationSpeed = 200f;

    [Header("Nuke Settings")]
    public float nukeDuration = 3f;
    private static bool isNukeActive = false;
    private static float nukeTimer = 0f;

    void Start()
    {
        if (GetComponent<Renderer>() != null) 
            GetComponent<Renderer>().material.color = new Color(1f, 0.84f, 0f);
    }

    void Update()
    {
        if (!transform.parent) 
        {
            float currentSpeed = GameManager.Instance != null ? GameManager.Instance.CurrentSpeed : 12f;
            transform.Translate(Vector3.back * currentSpeed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        if (isNukeActive)
        {
            nukeTimer -= Time.deltaTime;
            
            WipeTheBoard();

            if (nukeTimer <= 0f)
            {
                isNukeActive = false;
                Debug.Log("Radiation wore off. The gauntlet resumes!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" || other.CompareTag("Player"))
        {
            TriggerNuke();

            if (GetComponent<Renderer>()) GetComponent<Renderer>().enabled = false;
            if (GetComponent<Collider>()) GetComponent<Collider>().enabled = false;
            
            Destroy(gameObject, nukeDuration + 0.1f);
        }

        if (other.gameObject.name == "killbox") 
        {
            Destroy(gameObject);
        }
    }

    void TriggerNuke()
    {
        isNukeActive = true;
        nukeTimer = nukeDuration;
        Debug.Log("BOOM! NUKE ACTIVATED! VAPORIZING ALL CUBES! and adding radiation");
        
        WipeTheBoard();
    }

    void WipeTheBoard()
    {
        MonoBehaviour[] allScripts = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

        foreach (MonoBehaviour script in allScripts)
        {
            if (script == null || script.gameObject == null) continue;
            if (script.gameObject.name.Contains("Enemy") || 
                script.gameObject.name.Contains("Cube") || 
                script.gameObject.name.Contains("DISPA") || 
                script.GetType().Name == "ObstacleMovement" ||
                script.GetType().Name == "EvilCube" ||
                script.GetType().Name == "StalkerCube" ||
                script.GetType().Name == "ZigZagCube" ||
                script.GetType().Name == "PhasingCube" ||
                script.GetType().Name == "WallDespairCube")
            {
                if (script.gameObject != this.gameObject && !script.gameObject.CompareTag("Player") && script.gameObject.name != "Player")
                {
                    Destroy(script.gameObject);
                }
            }
        }

        Collider[] hitColliders = Physics.OverlapSphere(Vector3.zero, 200f);
        foreach (Collider hit in hitColliders)
        {
            if (hit == null || hit.gameObject == null) continue;

            if (hit.gameObject.name.Contains("Cube") || hit.gameObject.name.Contains("Enemy") || hit.gameObject.name.Contains("DISPA"))
            {
                if (hit.gameObject != this.gameObject && !hit.gameObject.CompareTag("Player") && hit.gameObject.name != "Player")
                {
                    Destroy(hit.gameObject);
                }
            }
        }
    }
}