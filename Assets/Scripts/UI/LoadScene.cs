using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Level sceneToLoad;
    public enum Level {
        LevelSelect,
        River,
        Ocean,
        Spawning,
        StevenTest
    }

    public void StartLoad() {
        SceneManager.LoadScene(sceneToLoad.ToString());
    }

    public void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene(sceneToLoad.ToString());
    }
}