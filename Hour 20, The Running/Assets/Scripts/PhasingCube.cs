using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasingCube : MonoBehaviour
{
    [Header("Expansion Settings")]
    public float expandSpeed = 3f;
    public float maxScale = 4f;

    void Update()
    {
        float dynamicForwardSpeed = GameManager.Instance.CurrentSpeed;

        transform.Translate(Vector3.back * dynamicForwardSpeed * Time.deltaTime, Space.World);

        if (transform.localScale.x < maxScale)
        {
            float newScale = transform.localScale.x + (expandSpeed * Time.deltaTime);
            newScale = Mathf.Min(newScale, maxScale);
            transform.localScale = new Vector3(newScale, newScale, newScale);
        }

        if (transform.position.z < -10f) Destroy(gameObject);
    }
}