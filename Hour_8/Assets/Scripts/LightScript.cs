using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    private Light lightComponent;

    void Start()
    {
        lightComponent = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            lightComponent.enabled = !lightComponent.enabled;
        }
    }
}
