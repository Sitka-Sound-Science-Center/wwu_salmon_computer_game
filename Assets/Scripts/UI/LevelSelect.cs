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
    //public ManagePhase mp;
    public FishButton active;
    private TouchListener TouchScript;

    public void SelectStage(FishButton stage) {
        ChooseSelectedLevel(stage.phase.ToString());
        ChooseSelectedStage(stage.phase); // signal load scene to load stage

        ManagePhase.SetPhase(stage.phase);

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

    public string ChooseSelectedStage(ManagePhase.Phase phase) {
        ManagePhase.SetPhase(phase);
        return ManagePhase.GetPhase().ToString();
    }

    public string ChooseSelectedLevel(string curStage) {
        Debug.Log("chooseselectedlevel " + curStage);
        if (curStage == "Alevin" || curStage == "Fry" || curStage == "Smolt") {
            loadScene.sceneToLoad = LoadScene.Level.River;
        } 
        else if (curStage == "Adult") {
            loadScene.sceneToLoad = LoadScene.Level.Ocean;
        } 
        else if (curStage == "Spawning") {
            loadScene.sceneToLoad = LoadScene.Level.Spawning;
        } 
        return loadScene.sceneToLoad.ToString();
    }

    void Start() {
        TouchScript = gameObject.GetComponent<TouchListener>();
        //mp = GameObject.FindWithTag("SpawnPoints").GetComponent<ManagePhase>();
        active=fishButtons[0];
        SelectStage(active);
    }
}
