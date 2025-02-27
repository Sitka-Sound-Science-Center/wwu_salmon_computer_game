using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class PauseMenuTests : MonoBehaviour
{
    public GameObject menu;
    public PauseMenu pm;
    public bool loaded=false;

    void MenuOnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (SceneManager.GetActiveScene().name == "River") loaded = true;
    }

    void SetPauseMenuTestRefs(Scene scene, LoadSceneMode mode) {
        menu = GameObject.Find("UICanvas/PauseMenu");
        pm = menu.GetComponent<PauseMenu>();
        ManagePhase.currentPhase = ManagePhase.Phase.Alevin;
    }

    [OneTimeSetUp]
    public void Init() {
        SceneManager.sceneLoaded += MenuOnSceneLoaded;
        SceneManager.sceneLoaded += SetPauseMenuTestRefs;

        // Only guarantees full scene load on next frame so tests must wait 
        SceneManager.LoadScene("River", LoadSceneMode.Single);
    } 

    [UnityTest]
    public IEnumerator TestPause() {
        yield return new WaitWhile(() => loaded == false);
        pm.Pause();
        Assert.That(UnityEngine.Time.timeScale, Is.EqualTo(0));
        UnityEngine.Time.timeScale = 1;
    }

    [UnityTest]
    public IEnumerator TestUnpause() {
        yield return new WaitWhile(() => loaded == false);
        pm.Unpause();
        Assert.That(UnityEngine.Time.timeScale, Is.EqualTo(1));
    }

    [UnityTest]
    public IEnumerator TestRestart() {
        yield return new WaitWhile(() => loaded == false);
        pm.Restart();
        Assert.That(UnityEngine.Time.timeScale, Is.EqualTo(1));
    }

    [UnityTest]
    public IEnumerator TestNextLevelWrapper() {
        yield return new WaitWhile(() => loaded == false);
        pm.NextLevel();
        Assert.That(ManagePhase.currentPhase, Is.EqualTo(ManagePhase.Phase.Fry));
    }    

    [OneTimeTearDown]
    public void TearDown() {
        SceneManager.sceneLoaded -= MenuOnSceneLoaded;
        SceneManager.sceneLoaded -= SetPauseMenuTestRefs;
    }
}