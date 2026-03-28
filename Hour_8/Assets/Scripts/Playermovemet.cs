using UnityEngine;

public class Playermovemet : MonoBehaviour
{
    void Update()
    {
        float mxVal = Input.GetAxis("Mouse X");
        float myVal = Input.GetAxis("Mouse Y");

        if (mxVal != 0)
            Debug.Log("Mouse X Movement detected: " + mxVal);

        if (myVal != 0)
            Debug.Log("Mouse Y Movement detected: " + myVal);

        if (Input.GetKey(KeyCode.M))
            Debug.Log("The 'M' Key is pressed!");

        if (Input.GetKey(KeyCode.O))
            Debug.Log("The 'O' Key is pressed!");

        float hVal = Input.GetAxis("Horizontal");
        float vVal = Input.GetAxis("Vertical");

        if (hVal != 0)
        {
            Debug.Log("Horizontal movement detected: " + hVal);
        }

        if (vVal != 0)
        {
            Debug.Log("Vertical movement detected: " + vVal);
        }
    } 
} 