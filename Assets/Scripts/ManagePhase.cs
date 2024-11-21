using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagePhase : MonoBehaviour
{
    private static Stage curStage = Stage.Alevin;
    private RiverSpawning sp;
    private GameObject Camera;

    public enum Stage {
        Alevin,
        Fry,
        Smolt,
        Adult,
        Spawning
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "River") {
            sp = GameObject.FindWithTag("RiverSpawns").GetComponent<RiverSpawning>();
            Camera = GameObject.FindWithTag("Camera");
            Vector3 PlayerPos = sp.Spawn(curStage.ToString());
            Camera.transform.position = new Vector3(PlayerPos.x, PlayerPos.y, -10);
        }
    }

    void Start() {
        SceneManager.sceneLoaded+=OnSceneLoaded; 
    }

    public Stage GetStage() {
        return curStage;
    }

    public void SetStage(Stage nxt) {
        curStage = nxt;
    }

    public void NextLevel() {
        if (curStage == Stage.Alevin || curStage == Stage.Fry) {
            curStage = (curStage==Stage.Alevin) ? Stage.Fry : Stage.Smolt;
            SceneManager.LoadScene("River");
        }
        else if (curStage == Stage.Smolt){
            curStage = Stage.Adult;
            SceneManager.LoadScene("Ocean");
        } 
        else if (curStage == Stage.Adult) {
            curStage = Stage.Spawning;
            SceneManager.LoadScene("Spawning"); 
        }
        else {
            curStage = Stage.Alevin;
            SceneManager.LoadScene("River");
        }
        UnityEngine.Time.timeScale = 1;
    }
}
