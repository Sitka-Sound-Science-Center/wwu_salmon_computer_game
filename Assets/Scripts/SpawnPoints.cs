using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public GameObject AlevinSpawn;
    public GameObject FrySpawn;
    public GameObject SmoltSpawn;
    public GameObject AdultSpawn;
    public GameObject SpawningSpawn;
    public GameObject Player;
    //private string[] stages = {"Alevin", "Fry", "Smolt", "Adult", "Spawning"}; // change to use the Stage enum?

    public Vector3 Spawn(ManagePhase.Phase phase) { // take Stage enum as param?
        Debug.Log("Spawning " + phase.ToString());
        int idx = (int)phase; // mod player transform #childs eg adult prefab will only have one child

        GameObject active = Player.transform.GetChild(idx).gameObject;
        Vector3 PlayerPos, SpawnPos;
        SpawnPos = gameObject.transform.GetChild(idx).position; 
        Player.transform.position = SpawnPos; 
        PlayerPos = active.transform.position;
        int zoom = 32;
        if (phase == ManagePhase.Phase.Fry) zoom = 50;
        if (phase == ManagePhase.Phase.Smolt) zoom = 70;
        GameObject.FindWithTag("Camera").GetComponent<Camera>().orthographicSize = zoom;
        //active.SetActive(true);
        return PlayerPos;
    }
}