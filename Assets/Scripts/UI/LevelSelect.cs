using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    public GameObject currentInfo;

    private TextMeshProUGUI curSpecies;
    private string curStage;
    public FishButton[] fishButtons;

    public LoadScene loadScene;


    public void SelectStage(FishButton stage)
    {
        curStage = stage.name;
        ChooseSelectedLevel();
        foreach (FishButton fish in fishButtons)
        {
            fish.SetSelect(stage == fish);
        }
    }

    public void SelectSpecies(string species)
    {
        curSpecies.text = species;
    }

    public void ChooseSelectedLevel()
    {
        if (curStage == "Eggs" || curStage == "Alevin"
            || curStage == "Fry" || curStage == "Smolt")
        {
            loadScene.sceneToLoad = LoadScene.Level.River;
        } else if (curStage == "Adult")
        {
            loadScene.sceneToLoad = LoadScene.Level.Ocean;
        } else if (curStage == "Spawning")
        {
            loadScene.sceneToLoad = LoadScene.Level.Spawning;
        } else
        {
            Debug.Log("Invalid level");
        }
    }
}
