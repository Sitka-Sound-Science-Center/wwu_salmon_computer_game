using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagePhase : MonoBehaviour
{
    private static Stage curStage = Stage.Alevin;
    private SpawnPoints sp;
    private GameObject Camera;

    public enum Stage {
        Alevin,
        Fry,
        Smolt,
        Adult,
        Spawning
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "River") { // TODO extend this to work in all three scenes?
            sp = GameObject.FindWithTag("SpawnPoints").GetComponent<SpawnPoints>();
            Camera = GameObject.FindWithTag("Camera");
            Vector3 PlayerPos = sp.Spawn(curStage.ToString());
            Camera.transform.position = new Vector3(PlayerPos.x, PlayerPos.y, -10);
        }
        if (scene.name == "Ocean")
        {
            curStage = Stage.Adult;
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
