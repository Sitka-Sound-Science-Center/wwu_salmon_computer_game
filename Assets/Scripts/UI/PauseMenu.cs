using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject credits;

    public void Pause() {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void Unpause() {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel() {
        ManagePhase.NextLevel();
    }

    public void ReturnToMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelSelect");
    }

    public void ShowCredits()
    {
        credits.SetActive(true);
        menu.SetActive(false);
    }

    public void HideCredits()
    {
        credits.SetActive(false);
        menu.SetActive(true);
    }
}
