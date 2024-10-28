using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelect : MonoBehaviour 
{
    public GameObject currentInfo;

    public TextMeshProUGUI curSpecies;
    public FishButton[] fishButtons;

    public LoadScene loadScene;


    public void SelectStage(FishButton stage) {
        ChooseSelectedLevel(stage.name);
        foreach (FishButton fish in fishButtons) {
            fish.SetSelect(stage == fish);
        }
    }

    public void SelectSpecies(string species) {
        curSpecies.text = species;
    }

    public string ChooseSelectedLevel(string curStage) {
        if (curStage == "Alevin" || curStage == "Fry" || curStage == "Smolt") {
            loadScene.sceneToLoad = LoadScene.Level.StevenTest;
        } 
        else if (curStage == "Adult") {
            loadScene.sceneToLoad = LoadScene.Level.StevenTest;
        } 
        else if (curStage == "Spawning") {
            loadScene.sceneToLoad = LoadScene.Level.StevenTest;
        } 
        return loadScene.sceneToLoad.ToString();
    }
}
