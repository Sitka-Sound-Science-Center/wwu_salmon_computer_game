using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class LevelSelectTests : MonoBehaviour
{
    public LoadScene LoadScript;
    public LevelSelect LevelScript;
    public GameObject ChangeButton;
    public GameObject[] FishButtons;
    public GameObject[] SpeciesButtons;
    public bool loaded=false;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        loaded = true;
    }

    void SetLevelSelectTestRefs(Scene scene, LoadSceneMode mode) {
        FishButtons = GameObject.FindGameObjectsWithTag("FishButton");
        SpeciesButtons = GameObject.FindGameObjectsWithTag("SpeciesButton");
        ChangeButton = GameObject.FindWithTag("ChangeButton");
        LoadScript = GameObject.FindWithTag("StartButton").GetComponent<LoadScene>();
        LevelScript = GameObject.FindWithTag("Canvas").GetComponent<LevelSelect>();
    }

    [OneTimeSetUp]
    public void Init() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneLoaded += SetLevelSelectTestRefs;

        // Only guarantees full scene load on next frame so tests must wait 
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    } 

    // TODO MAKE TEARDOWN FOR THIS TEST SUITE?? //

    [UnityTest]
    public IEnumerator TestPhaseInfoBoxes() {
        yield return new WaitWhile(() => loaded == false);
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
        ChangeButton.GetComponent<Button>().onClick.Invoke();
        GameObject SpeciesScreen = GameObject.FindWithTag("SpeciesScreen");
        Assert.That((SpeciesScreen != null), Is.EqualTo(true));
        SpeciesScreen.SetActive(false);
    }

    [UnityTest]
    public IEnumerator TestSpeciesSelect() {
        yield return new WaitWhile(() => loaded == false);
        ChangeButton.GetComponent<Button>().onClick.Invoke();
        GameObject SpeciesScreen = GameObject.FindWithTag("SpeciesScreen");
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
}