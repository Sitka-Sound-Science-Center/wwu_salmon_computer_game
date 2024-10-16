using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;

    public void StartLoad()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

