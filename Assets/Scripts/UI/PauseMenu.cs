using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }
}
