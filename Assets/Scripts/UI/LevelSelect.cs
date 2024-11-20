using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    public FishButton[] fishButtons;
    public GameObject currentInfo;

    public TextMeshProUGUI curSpecies;
    public GameObject curSpeciesIcon;

    public LoadScene loadScene;
    public ManagePhase mp;
    public FishButton active;
    private TouchListener TouchScript;

    public void SelectStage(FishButton stage) {
        ChooseSelectedLevel(stage.name);
        active.SetSelect(false);
        stage.SetSelect(true);
        active=stage;
        TouchScript.SetState(active);
    }

    public void SelectSpecies(FishButton fish) {
        curSpecies.text = fish.name;
        fish.icon.SetActive(true);
        curSpeciesIcon.SetActive(false);
        curSpeciesIcon = fish.icon;
    }

    public string ChooseSelectedStage(string curStage) {
        if (curStage == "Alevin") mp.SetStage(ManagePhase.Stage.Alevin); 
        else if (curStage == "Fry") mp.SetStage(ManagePhase.Stage.Fry);
        else mp.SetStage(ManagePhase.Stage.Smolt);
        return mp.GetStage().ToString();
    }

    public string ChooseSelectedLevel(string curStage) {
        if (curStage == "Alevin" || curStage == "Fry" || curStage == "Smolt") {
            loadScene.sceneToLoad = LoadScene.Level.River; 
            ChooseSelectedStage(curStage); // signal load scene to load stage
        } 
        else if (curStage == "Adult") {
            //loadScene.sceneToLoad = LoadScene.Level.Ocean;
            loadScene.sceneToLoad = LoadScene.Level.River;
        } 
        else if (curStage == "Spawning") {
            //loadScene.sceneToLoad = LoadScene.Level.Spawning;
            loadScene.sceneToLoad = LoadScene.Level.River;
        } 
        return loadScene.sceneToLoad.ToString();
    }

    void Start() {
        TouchScript = gameObject.GetComponent<TouchListener>();
        mp = GameObject.FindWithTag("RiverSpawns").GetComponent<ManagePhase>();
        active=fishButtons[0];
        SelectStage(active);
    }
}
