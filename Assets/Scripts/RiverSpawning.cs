using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverSpawning : MonoBehaviour
{
    public GameObject FrySpawn;
    public GameObject SmoltSpawn;
    public GameObject Player;

    void Spawn(string stage) {
        GameObject active;
        if (stage=="Fry"){
            active = Player.transform.GetChild(1).gameObject;
            active.SetActive(true); // activate the desired player obj
            // update player obj position to spawn point
            active.transform.position = gameObject.transform.GetChild(1).position; 
        } 
        else if (stage=="Smolt") {
            active = Player.transform.GetChild(2).gameObject;
            active.SetActive(true); // activate the desired player obj
            // update player obj position to spawn point
            active.transform.position = gameObject.transform.GetChild(2).position; 
        }
    }
}
