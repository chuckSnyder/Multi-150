using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float laneSpeed = 15f; 
    public float xRange = 4.5f;   
    [Range(0.1f, 3.0f)] public float sensitivityMultiplier = 1.0f; // New sensitivity slider!

    [Header("Power-up State")]
    private bool isShielded = false;
    private float shieldTimer = 0f;
    private Material playerMaterial;
    private Color originalColor;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            playerMaterial = renderer.material;
            originalColor = playerMaterial.color;
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        
        // Sensitivity multiplier applied directly to the movement calculation
        float newXPosition = transform.position.x + (horizontalInput * laneSpeed * sensitivityMultiplier * Time.deltaTime);
        
        newXPosition = Mathf.Clamp(newXPosition, -xRange, xRange);
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);

        if (isShielded)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0)
            {
                DeactivateShield();
            }
        }
    }

    public void ActivateShield(float duration)
    {
        isShielded = true;
        shieldTimer = duration;

        if (playerMaterial != null) playerMaterial.color = Color.cyan;
    }

    void DeactivateShield()
    {
        isShielded = false;
        if (playerMaterial != null) playerMaterial.color = originalColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "killbox" || 
            other.gameObject.name.Contains("Track") || 
            other.gameObject.name.Contains("Floor") ||
            other.gameObject.name.Contains("Wall"))
        {
            return; 
        }

        if (other.GetComponent<PowerUp>() != null || other.gameObject.name.Contains("PowerUp"))
        {
            return;
        }

        // Check if the player is collecting the external Totem item
        if (other.gameObject.name.Contains("Totem") || other.GetComponent("TotemPowerUp") != null)
        {
            TotemPowerUp.HasTotem = true;
            Debug.Log("TOTEM OF UNDYING ACQUIRED! Stored in passive inventory.");
            Destroy(other.gameObject);
            return;
        }

        bool isEnemy = other.GetComponent<EvilCube>() != null || 
                       other.GetComponent<ObstacleMovement>() != null || 
                       other.GetComponent<StalkerCube>() != null || 
                       other.GetComponent<WallDespairCube>() != null ||
                       other.GetComponent<PhasingCube>() != null ||
                       other.GetComponent<ZigZagCube>() != null;

        if (!isEnemy) return;

        if (isShielded)
        {
            Debug.Log("SHIELD Shielded: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
        else if (TotemPowerUp.HasTotem)
        {
            TotemPowerUp.HasTotem = false;
            Debug.Log("TOTEM POPPED! Fatal crash intercepted safely!");
            Destroy(other.gameObject); 
        }
        else
        {
            Debug.Log("CRASHED INTO: " + other.gameObject.name + "! Back to the menu.");
            
            StartCoroutine(PlayDeathAndLoadMenu());
        }
    }

    private IEnumerator PlayDeathAndLoadMenu()
    {
        AudioClip clip = Resources.Load<AudioClip>("DeathSound");
        float delayTime = 0.5f; 

        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            delayTime = clip.length;
        }

        if (GetComponent<Renderer>()) GetComponent<Renderer>().enabled = false;
        laneSpeed = 0f; 

        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene("MainMenu"); 
    }
}