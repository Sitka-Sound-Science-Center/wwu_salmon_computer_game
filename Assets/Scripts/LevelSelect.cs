using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public GameObject currentInfo;

    private string species;
    private string stage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectStage(GameObject info)
    {
        currentInfo.SetActive(false);
        currentInfo = info;
        info.SetActive(true);

        //set select highlight
    }

    public void SelectSpecies(string species)
    {
        this.species = species;
    }
}
