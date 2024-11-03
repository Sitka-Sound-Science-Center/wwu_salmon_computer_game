using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadScene : MonoBehaviour
{
    public Level sceneToLoad;

    public GameObject loadingScreen;
    private Slider progressBar;
    private TextMeshProUGUI message;

    AsyncOperation loadingOperation;

    void Start()
    {
        loadingScreen.SetActive(false);
    }

    public enum Level {
        LevelSelect,
        River,
        Ocean,
        Spawning
    }

    public void StartLoad() {
        SceneManager.LoadScene(sceneToLoad.ToString());
    }

    public void StartLoadAsync()
    {
        loadingScreen.SetActive(true);
        message = loadingScreen.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        progressBar = loadingScreen.transform.GetChild(1).gameObject.GetComponent<Slider>();
        message.text = "";

        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad.ToString());
        loadingOperation.allowSceneActivation = false;
        StartCoroutine(WaitForLoad());
    }

    IEnumerator WaitForLoad()
    {
        yield return new WaitForSeconds(0.5f);

        progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);

        while (!loadingOperation.isDone)
        {
            if (loadingOperation.progress >= 0.9f)
            {
                message.text = "CLICK ANYWHERE TO CONTINUE";
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    loadingOperation.allowSceneActivation = true;
                    //yield break;
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene(sceneToLoad.ToString());
    }
}