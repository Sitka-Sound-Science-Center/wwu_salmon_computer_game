using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverSpawning : MonoBehaviour
{
    public GameObject AlevinSpawn;
    public GameObject FrySpawn;
    public GameObject SmoltSpawn;
    public GameObject Player;

    public Vector3 Spawn(string stage) {
        GameObject active;
        Vector3 SpawnPos;
        if (stage=="Alevin") {
            active = Player.transform.GetChild(0).gameObject;
            SpawnPos = gameObject.transform.GetChild(0).position; 
        }
        
        if (stage=="Fry") {
            active = Player.transform.GetChild(1).gameObject;
            SpawnPos = gameObject.transform.GetChild(1).position; 
        }  
        
        else {
            active = Player.transform.GetChild(2).gameObject;
            SpawnPos = gameObject.transform.GetChild(2).position; 
        } 
        active.SetActive(true);
        Player.transform.position = SpawnPos; 
        return active.transform.position;
    }
}
