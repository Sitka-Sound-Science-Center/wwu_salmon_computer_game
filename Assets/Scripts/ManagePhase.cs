using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagePhase : ScriptableObject
{
    public static Phase currentPhase;

    public enum Phase {
        Alevin,
        Fry,
        Smolt,
        Adult,
        Spawning
    }

    public static Phase GetPhase() {
        return currentPhase;
    }

    public static void SetPhase(Phase nxt) {
        currentPhase = nxt;
    }

    public static void NextLevel() {
        if (currentPhase == Phase.Alevin || currentPhase == Phase.Fry) {
            currentPhase = (currentPhase == Phase.Alevin) ? Phase.Fry : Phase.Smolt;
            SceneManager.LoadScene("River");
        }
        else if (currentPhase == Phase.Smolt){
            currentPhase = Phase.Adult;
            SceneManager.LoadScene("Ocean");
        } 
        else if (currentPhase == Phase.Adult) {
            currentPhase = Phase.Spawning;
            SceneManager.LoadScene("Spawning"); 
        }
        else {
            currentPhase = Phase.Alevin;
            SceneManager.LoadScene("River");
        }
        UnityEngine.Time.timeScale = 1;
    }
}
