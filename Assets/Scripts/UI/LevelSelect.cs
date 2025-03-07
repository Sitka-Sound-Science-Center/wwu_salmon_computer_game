using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    public FishButton[] fishButtons;
    public GameObject currentInfo;

    public TextMeshProUGUI curSpecies;
    public GameObject speciesParent;
    public GameObject curSpeciesIcon;

    public LoadScene loadScene;
    //public ManagePhase mp;
    public FishButton active;
    private TouchListener TouchScript;

    void Start()
    {
        TouchScript = gameObject.GetComponent<TouchListener>();
        //mp = GameObject.FindWithTag("SpawnPoints").GetComponent<ManagePhase>();
        active = fishButtons[0];
        SelectStage(active);
        SelectSpeciesFish(SpeciesManager.curSpecies);
    }

    public void SelectStage(FishButton stage) {
        ChooseSelectedLevel(stage.phase.ToString());
        ChooseSelectedStage(stage.phase); // signal load scene to load stage

        ManagePhase.SetPhase(stage.phase);

        active.SetSelect(false);
        stage.SetSelect(true);
        active=stage;
        TouchScript.SetState(active);
    }

    public void SelectSpeciesFish(SpeciesManager.Species fish) {
        curSpecies.text = fish.ToString();
        curSpeciesIcon.SetActive(false);
        //curSpeciesIcon = fish.icon;
        curSpeciesIcon = speciesParent.transform.Find(fish.ToString()).gameObject;
        curSpeciesIcon.SetActive(true);
        SpeciesManager.SetSpecies(fish);
    }

    public void SelectSpecies(int fish)
    {
        SelectSpeciesFish((SpeciesManager.Species)fish);
    }

    public void RefreshImages()
    {
        fishButtons[3].RefreshImage();
        fishButtons[4].RefreshImage();
    }

    public string ChooseSelectedStage(ManagePhase.Phase phase) {
        ManagePhase.SetPhase(phase);
        return ManagePhase.GetPhase().ToString();
    }

    public string ChooseSelectedLevel(string curStage) {
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
}
