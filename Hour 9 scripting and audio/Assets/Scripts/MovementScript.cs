using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // "Input" and "GetAxis" must be capitalized
        // The axis names "Mouse X" and "Mouse Y" are also case-sensitive strings
        float mX = Input.GetAxis("Mouse X") / 10;
        float mY = Input.GetAxis("Mouse Y") / 10;
        
        transform.Translate(mX, mY, 0);
    }
}