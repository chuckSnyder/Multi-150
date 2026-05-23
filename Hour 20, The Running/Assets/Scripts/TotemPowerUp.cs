using UnityEngine;

public class TotemPowerUp : MonoBehaviour
{
    [Header("Movement")]
    public float rotationSpeed = 300f;

    // Global variables read directly by your existing Player Controller
    public static bool HasTotem = false;
    public static int ActiveTotemCount = 0; // Left here so Spawner.cs doesn't break, but no longer restricting spawns!

    private bool isCollected = false;
    private bool wasPopLogged = false;

    void Start()
    {
        // Exotic Gold appearance
        if (GetComponent<Renderer>() != null) 
            GetComponent<Renderer>().material.color = new Color(1f, 0.85f, 0f); 
    }

    void Update()
    {
        // 1. Move down the track normally ONLY if it hasn't been picked up yet
        if (!isCollected && !transform.parent) 
        {
            float currentSpeed = GameManager.Instance != null ? GameManager.Instance.CurrentSpeed : 12f;
            transform.Translate(Vector3.back * currentSpeed * Time.deltaTime, Space.World);
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        // 2. DETECT PICKUP
        // Only allow collection if the player doesn't already have one secured!
        if (!isCollected && HasTotem)
        {
            isCollected = true;
            gameObject.SetActive(false); // Instantly hide the item object safely
        }

        // 3. DETECT THE POP AND LOG IT
        if (isCollected && !wasPopLogged && !HasTotem)
        {
            wasPopLogged = true;
            
            Debug.Log("🌟 TOTEM POPPED! Fatal crash intercepted safely!");

            Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Safe boundary cleanup if missed completely by the player
        if (other.gameObject.name == "killbox" && !isCollected) 
        {
            Destroy(gameObject);
        }
    }
}