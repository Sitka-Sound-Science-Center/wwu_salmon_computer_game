using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public GameObject currentInfo;

    private string curSpecies;
    private string curStage;
    public FishButton[] fishButtons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectStage(FishButton stage)
    {
        foreach (FishButton fish in fishButtons)
        {
            fish.SetSelect(stage == fish);
        }
    }

    public void SelectSpecies(string species)
    {
        this.curSpecies = species;
    }
}
