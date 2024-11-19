using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadScene : MonoBehaviour
{
    public Level sceneToLoad;
    public Stage stageToLoad;
    public GameObject loadingScreen;
    public GameObject Camera;
    public Slider progressBar;
    public TextMeshProUGUI message;
    public RiverSpawning sp;
    AsyncOperation loadingOperation;

    public enum Level {
        LevelSelect,
        River,
        Ocean,
        Spawning
    }

    public enum Stage {
        Alevin,
        Fry,
        Smolt,
    }

    void Start() {
        if (loadingScreen != null) {
            loadingScreen.SetActive(false);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        sp = GameObject.FindWithTag("RiverSpawns").GetComponent<RiverSpawning>();
        Camera = GameObject.FindWithTag("Camera");
        string stage = stageToLoad.ToString();
        print(stage);
        if (scene.name=="River"){
            Vector3 PlayerPos = sp.Spawn(stage);
            Camera.transform.position = new Vector3(PlayerPos.x, PlayerPos.y, -10);
        } 
    }

    public void StartLoad() {
        SceneManager.LoadScene(sceneToLoad.ToString());
    }

    public void StartLoadAsync() {
        loadingScreen.SetActive(true);
        //message = loadingScreen.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        //progressBar = loadingScreen.transform.GetChild(1).gameObject.GetComponent<Slider>();
        message.text = "LOADING...";

        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad.ToString());
        loadingOperation.allowSceneActivation = false;
        SceneManager.sceneLoaded+=OnSceneLoaded;
        StartCoroutine(WaitForLoad());
    }

    IEnumerator WaitForLoad() {
        yield return new WaitForSeconds(0.2f);
        //progressBar.value = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        while (!loadingOperation.isDone) {
            if (loadingOperation.progress >= 0.9f && progressBar.value == 1) {
                progressBar.value = 1;
                message.text = "CLICK ANYWHERE TO CONTINUE";
                if (Input.GetKeyDown(KeyCode.Mouse0)) {
                    loadingOperation.allowSceneActivation = true;
                }
            } 
            else {
                // fake loading, makes progress bar look better when loading too fast
                progressBar.value += 0.1f;
                yield return new WaitForSeconds(0.05f);
            }
            yield return null;
        }

    }

    public void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene(sceneToLoad.ToString());
    }
}