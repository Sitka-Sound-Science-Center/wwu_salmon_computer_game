using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;

    public void Pause() {
        UnityEngine.Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void Unpause() {
        UnityEngine.Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void InfoMenu() {
        Debug.Log("Opening info menu");
    }

    public void Restart() {
        UnityEngine.Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu() {
        UnityEngine.Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }

    public void Exit() {
        // quit editor or exit application
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
    }
}
