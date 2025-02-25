using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class ManagePhaseTests : MonoBehaviour
{
    public bool loaded=false;

    void MPOnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (SceneManager.GetActiveScene().name == "River") loaded = true;
    }

    [OneTimeSetUp]
    public void Init() {
        SceneManager.sceneLoaded += MPOnSceneLoaded;

        // Only guarantees full scene load on next frame so tests must wait 
        SceneManager.LoadScene("River", LoadSceneMode.Single);
    } 

    [UnityTest]
    public IEnumerator TestNextLevelFry() {
        yield return new WaitWhile(() => loaded == false);
        ManagePhase.currentPhase = ManagePhase.Phase.Alevin;
        ManagePhase.NextLevel();
        Assert.That(ManagePhase.Phase.Fry, Is.EqualTo(ManagePhase.currentPhase));
    }

    [UnityTest]
    public IEnumerator TestNextLevelAdult() {
        yield return new WaitWhile(() => loaded == false);
        ManagePhase.currentPhase = ManagePhase.Phase.Smolt;
        ManagePhase.NextLevel();
        Assert.That(ManagePhase.Phase.Adult, Is.EqualTo(ManagePhase.currentPhase));
    }

    [UnityTest]
    public IEnumerator TestNextLevelSpawning() {
        yield return new WaitWhile(() => loaded == false);
        ManagePhase.currentPhase = ManagePhase.Phase.Adult;
        ManagePhase.NextLevel();
        Assert.That(ManagePhase.Phase.Spawning, Is.EqualTo(ManagePhase.currentPhase));
    }

    [UnityTest]
    public IEnumerator TestNextLevelAlevin() {
        yield return new WaitWhile(() => loaded == false);
        ManagePhase.currentPhase = ManagePhase.Phase.Spawning;
        ManagePhase.NextLevel();
        Assert.That(ManagePhase.Phase.Alevin, Is.EqualTo(ManagePhase.currentPhase));
    }

    [OneTimeTearDown]
    public void TearDown() {
        SceneManager.sceneLoaded -= MPOnSceneLoaded;
    }
}