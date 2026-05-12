using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void GoToParticles()
    {
        // This tells Unity: "Go find the scene named exactly like this"
        // Replace 'Hour 16' with whatever you actually named your Hour 16 scene!
        SceneManager.LoadScene("Hour 16");
    }
}
