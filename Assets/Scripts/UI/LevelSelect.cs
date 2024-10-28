using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    public FishButton[] fishButtons;
    public GameObject currentInfo;
    public TextMeshProUGUI curSpecies;
    public LoadScene loadScene;
    public FishButton active;
    private TouchListener TouchScript;

    public void SelectStage(FishButton stage) {
        ChooseSelectedLevel(stage.name);
        active.SetSelect(false);
        stage.SetSelect(true);
        active=stage;
    }

    public void SelectSpecies(string species) {
        curSpecies.text = species;
    }

    public string ChooseSelectedLevel(string curStage) {
        if (curStage == "Alevin" || curStage == "Fry" || curStage == "Smolt") {
            loadScene.sceneToLoad = LoadScene.Level.River;
        } 
        else if (curStage == "Adult") {
            loadScene.sceneToLoad = LoadScene.Level.River;
        } 
        else if (curStage == "Spawning") {
            loadScene.sceneToLoad = LoadScene.Level.River;
        } 
        return loadScene.sceneToLoad.ToString();
    }

    void Awake() {
        TouchScript = gameObject.GetComponent<TouchListener>();
        active=fishButtons[0];
        SelectStage(active);
    }
}
