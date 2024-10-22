using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;
using TMPro;

[TestFixture]
public class LevelSelectTests : MonoBehaviour
{
    public LoadScene LoadScript;
    public LevelSelect LevelScript;
    public GameObject SpeciesScreen;
    public GameObject[] FishButtons;
    public GameObject[] SpeciesButtons;
    public bool loaded=false;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        loaded = true;
    }

    [OneTimeSetUp]
    public void Init() {
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Only guarantees full scene load on next frame so tests must wait 
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    } 

    // MAKE GLOBAL WAIT ONE FRAME SET REFS FUNCTION 

    [UnityTest]
    public IEnumerator TestPhaseInfoBoxes() {
        yield return new WaitWhile(() => loaded == false);
        FishButtons = GameObject.FindGameObjectsWithTag("FishButton");
        foreach (GameObject fish in FishButtons) {
            fish.GetComponent<Button>().onClick.Invoke();
            string InfoBoxName = fish.name + "Info";
            GameObject InfoBox = GameObject.FindWithTag("InfoBox");
            Assert.That(InfoBoxName, Is.EqualTo(InfoBox.name));
        }
    }

    // TODO TEST THAT CHECKS IF CORRECT SET OF ASSETS IS DISPLAYED ON MAIN MENU SCREEN WHEN SPECIES CHANGES
    // TODO TEST THAT IDLE TIMER BEGINS AT APPROPRIATE TIME AND ANIMATION IS CORRECTLY STARTED THEN STOPPED ON NEXT TOUCH

    [UnityTest]
    public IEnumerator TestLevelSelect() {
        yield return new WaitWhile(() => loaded == false);
        FishButtons = GameObject.FindGameObjectsWithTag("FishButton");
        LoadScript = GameObject.FindWithTag("StartButton").GetComponent<LoadScene>();
        foreach (GameObject fish in FishButtons) {
            fish.GetComponent<Button>().onClick.Invoke();
            string curStage = fish.name;
            string sceneToLoad = LoadScript.sceneToLoad.ToString();
            if (curStage == "Alevin" || curStage == "Fry" || curStage == "Smolt") {
                Assert.That(sceneToLoad, Is.EqualTo("River"));
            } 
            else if (curStage == "Adult") {
                Assert.That(sceneToLoad, Is.EqualTo("Ocean"));
            } 
            else if (curStage == "Spawning") {
                Assert.That(sceneToLoad, Is.EqualTo("Spawning"));
            } 
        }
    }

    [UnityTest]
    public IEnumerator TestChangeButton() {
        yield return new WaitWhile(() => loaded == false);
        GameObject ChangeButton = GameObject.FindWithTag("ChangeButton");
        ChangeButton.GetComponent<Button>().onClick.Invoke();
        GameObject SpeciesScreen = GameObject.FindWithTag("SpeciesScreen");
        Assert.That((SpeciesScreen != null), Is.EqualTo(true));
        SpeciesScreen.SetActive(false);
    }

    [UnityTest]
    public IEnumerator TestSpeciesSelect() {
        yield return new WaitWhile(() => loaded == false);
        LevelScript = GameObject.FindWithTag("Canvas").GetComponent<LevelSelect>();
        GameObject ChangeButton = GameObject.FindWithTag("ChangeButton");
        ChangeButton.GetComponent<Button>().onClick.Invoke();
        GameObject SpeciesScreen = GameObject.FindWithTag("SpeciesScreen");
        SpeciesButtons = GameObject.FindGameObjectsWithTag("SpeciesButton");
        foreach (GameObject species in SpeciesButtons) {
            species.GetComponent<Button>().onClick.Invoke();
            Assert.That(SpeciesScreen.activeSelf, Is.False);

            // Each species select button has a parent object with the species name for the button
            string selectedSpecies = species.transform.parent.gameObject.name;
            string curSpecies = LevelScript.curSpecies.text;
            Assert.That(curSpecies, Is.EqualTo(selectedSpecies));
            SpeciesScreen.SetActive(true);
        }
        SpeciesScreen.SetActive(false);
    }

    /* 
     !!! LEGACY TESTING CODE !!!
    
    [SerializeField]
    bool TestingEnabled = false; // !!! SET TO TRUE IN EDITOR TO RUN TESTS ON SCENE LOAD !!! //

    void Start() {
        if (TestingEnabled) {
        // Start button has LoadScene script attached, where each fish button
        // on level select screen will set the sceneToLoad variable
        RunTests();
    }

    public void RunTests() {
        TestLevelSelect();
        TestChangeButton();
        TestSpeciesSelect();
    }
    */
}