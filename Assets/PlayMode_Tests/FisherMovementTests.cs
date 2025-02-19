using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class FisherMovementTests : MonoBehaviour
{
    public GameObject Boat;
    public FisherMovement MovementScript;
    public bool loaded=false;

    void OceanOnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (SceneManager.GetActiveScene().name == "Ocean") loaded = true;
    }

    void SetFisherMovementTestRefs(Scene scene, LoadSceneMode mode) {
        Boat = GameObject.Find("Predators/Fisherman");
        MovementScript = Boat.GetComponent<FisherMovement>();
        MovementScript.CastFrequency = 0.1F;
    }

    [OneTimeSetUp]
    public void Init() {
        SceneManager.sceneLoaded += OceanOnSceneLoaded;
        SceneManager.sceneLoaded += SetFisherMovementTestRefs;

        // Only guarantees full scene load on next frame so tests must wait 
        SceneManager.LoadScene("Ocean", LoadSceneMode.Single);
    } 
    
    
    [UnityTest]
    public IEnumerator TestSpawnFishHook() {
        yield return new WaitWhile(() => loaded == false);
        yield return new WaitForSeconds(0.1F); 
        Assert.That(MovementScript.LineCount, Is.EqualTo(1));
    }

    
    [UnityTest]
    public IEnumerator TestDestroyFishHook() {
        yield return new WaitWhile(() => loaded == false);
        yield return new WaitForSeconds(0.2F); 
        Assert.That(MovementScript.LineCount, Is.EqualTo(0));
    }

    [OneTimeTearDown]
    public void TearDown() {
        SceneManager.sceneLoaded -= OceanOnSceneLoaded;
        SceneManager.sceneLoaded -= SetFisherMovementTestRefs;
    }
}