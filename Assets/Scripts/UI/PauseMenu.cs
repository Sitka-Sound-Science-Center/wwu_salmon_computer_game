using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;

    public void Pause()
    {
        UnityEngine.Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void Unpause()
    {
        UnityEngine.Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void InfoMenu()
    {
        Debug.Log("Opening info menu");
    }

    public void Restart() {
        //added because death screens restarted paused
        UnityEngine.Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Exit() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }
}
