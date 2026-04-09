using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private AudioSource myAudio;

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        ToggleAudio();
    }

    void ToggleAudio()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (myAudio.isPlaying)
            {
                myAudio.Pause();
            }
            else
            {
                myAudio.Play();
            }
        }
    }
}
