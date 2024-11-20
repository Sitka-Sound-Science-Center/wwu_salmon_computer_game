using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverSpawning : MonoBehaviour
{
    public GameObject AlevinSpawn;
    public GameObject FrySpawn;
    public GameObject SmoltSpawn;
    public GameObject Player;

    // Helper to map string stage name to index
    private int stageIndex(string stage) {
        if (stage=="Alevin") return 0;
        else if (stage=="Fry") return 1;
        else return 2;
    }

    public Vector3 Spawn(string stage) {
        int idx=stageIndex(stage); 
        GameObject active = Player.transform.GetChild(idx).gameObject;
        Vector3 PlayerPos, SpawnPos;
        SpawnPos = gameObject.transform.GetChild(idx).position; 
        Player.transform.position = SpawnPos; 
        PlayerPos = active.transform.position;
        active.SetActive(true);
        return PlayerPos;
    }
}
