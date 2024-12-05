using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public GameObject AlevinSpawn;
    public GameObject FrySpawn;
    public GameObject SmoltSpawn;
    public GameObject AdultSpawn;
    public GameObject SpawningSpawn;
    public GameObject Player;
    private string[] stages = {"Alevin", "Fry", "Smolt", "Adult", "Spawning"}; // change to use the Stage enum?

    public Vector3 Spawn(string stage) { // take Stage enum as param?
        int idx = System.Array.IndexOf(stages,stage); // mod player transform #childs eg adult prefab will only have one child
        GameObject active = Player.transform.GetChild(idx).gameObject;
        Vector3 PlayerPos, SpawnPos;
        SpawnPos = gameObject.transform.GetChild(idx).position; 
        Player.transform.position = SpawnPos; 
        PlayerPos = active.transform.position;
        active.SetActive(true);
        return PlayerPos;
    }
}
