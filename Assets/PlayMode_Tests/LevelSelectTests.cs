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
    public GameObject SpeciesScreen;
    public GameObject[] FishButtons;
    public GameObject[] SpeciesButtons;
    public bool loaded=false;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        loaded = true;
    }

    [OneTimeSetUp]
    public void Init() {
        print("Level select test init");
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Only guarantees full scene load on next frame so tests must wait 
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    } 

    [UnityTest]
    public IEnumerator TestLevelSelect() {
        yield return new WaitWhile(() => loaded == false);
        FishButtons = GameObject.FindGameObjectsWithTag("FishButton");
        LoadScript = GameObject.FindWithTag("StartButton").GetComponent<LoadScene>();
        foreach (GameObject fish in FishButtons) {
            fish.GetComponent<Button>().onClick.Invoke();
            string curStage = fish.name;
            string sceneToLoad = LoadScript.sceneToLoad.ToString();
            print(curStage + " " + sceneToLoad);
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

    public void TestSpeciesSelect() {
        //GameObject ChangeButton = GameObject.FindWithTag("ChangeButton"); 
        //GameObject SpeciesScreen;
        //foreach (GameObject species in SpeciesButtons) {
        //    SpeciesScreen.SetActive(true);
        //    species.GetComponent<Button>().onClick.Invoke();
        //}
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