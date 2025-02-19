using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class PredatorControllerTests : MonoBehaviour
{
    public GameObject Player;
    public GameObject SealSpawner;
    public PredatorController ControlScript;
    public bool loaded=false;

    void OceanOnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (SceneManager.GetActiveScene().name == "Ocean") loaded = true;
    }

    void SetPredatorControllerTestRefs(Scene scene, LoadSceneMode mode) {
        Player = GameObject.FindWithTag("Player");
        SealSpawner = GameObject.Find("Predators/AssetSpawner(fish)");
        ControlScript = SealSpawner.GetComponent<PredatorController>();
    }

    [OneTimeSetUp]
    public void Init() {
        SceneManager.sceneLoaded += OceanOnSceneLoaded;
        SceneManager.sceneLoaded += SetPredatorControllerTestRefs;

        // Only guarantees full scene load on next frame so tests must wait 
        SceneManager.LoadScene("Ocean", LoadSceneMode.Single);
    } 
    
    
    [UnityTest]
    public IEnumerator TestCountChildrenOnLoad() {
        yield return new WaitWhile(() => loaded == false);
        Assert.That(ControlScript.CountPredators(), Is.EqualTo(1));
    }
    
    [UnityTest]
    public IEnumerator TestMaxCountChildren() {
        yield return new WaitWhile(() => loaded == false);
        ControlScript.SetSpawnDelay(1);
        yield return new WaitForSeconds(0.1F); // dependent on max predator value 
        Assert.That(ControlScript.CountPredators(), Is.EqualTo(ControlScript.maxpredator));
    }

    [UnityTest]
    public IEnumerator TestPointOffScreen() {
        yield return new WaitWhile(() => loaded == false);
        Vector3 p = ControlScript.Camera.ViewportToWorldPoint(new Vector3(2,2,0));
        Assert.That(ControlScript.PointOnScreen(p), Is.False);
    }

    [UnityTest]
    public IEnumerator TestPointOnScreen() {
        yield return new WaitWhile(() => loaded == false);
        Vector3 p = ControlScript.Camera.ViewportToWorldPoint(new Vector3(0.75F,0.5F,0.1F));
        Assert.That(ControlScript.PointOnScreen(p), Is.True);
    }

    [OneTimeTearDown]
    public void TearDown() {
        SceneManager.sceneLoaded -= OceanOnSceneLoaded;
        SceneManager.sceneLoaded -= SetPredatorControllerTestRefs;
    }
}