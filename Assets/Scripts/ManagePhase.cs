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
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "River") {
            if (curStage == Stage.Alevin) sp.Spawn("Fry");
            else if (curStage == Stage.Fry) sp.Spawn("Smolt");
            else SceneManager.LoadScene("Ocean"); 
        }
        else if (sceneName == "Ocean") SceneManager.LoadScene("Spawning");
        else {
            SceneManager.LoadScene("River");
            sp.Spawn("Alevin");
        }
    }
}
