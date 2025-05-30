using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class EnemyFOVTests : MonoBehaviour
{
    public GameObject Player;
    public GameObject Predator;
    public EnemyFOV FOVScript;
    public PredatorMovement MovementScript;
    public bool loaded=false;

    void OceanOnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (SceneManager.GetActiveScene().name == "Ocean") loaded = true;
    }

    void SetEnemyFOVTestRefs(Scene scene, LoadSceneMode mode) {
        Player = GameObject.FindWithTag("Player");
        Predator = GameObject.Find("Predators/Lingcod");
        MovementScript = Predator.GetComponent<PredatorMovement>();
        FOVScript = Predator.GetComponent<EnemyFOV>();
    }

    [OneTimeSetUp]
    public void Init() {
        SceneManager.sceneLoaded += OceanOnSceneLoaded;
        SceneManager.sceneLoaded += SetEnemyFOVTestRefs;

        // Only guarantees full scene load on next frame so tests must wait 
        SceneManager.LoadScene("Ocean", LoadSceneMode.Single);
    } 

    [UnityTest]
    public IEnumerator TestNotInDetectionConeTop() {
        // Position of player for test depends on enemy detection angle
        yield return new WaitWhile(() => loaded == false);
        Player.transform.position = new Vector3(0,100,0);
        Predator.transform.position = new Vector3(100,0,0);
        Assert.That(FOVScript.IsPlayerInCone(Player.transform.position), Is.False);
    }

    [UnityTest]
    public IEnumerator TestNotInDetectionConeBottom() {
        // Position of player for test depends on enemy detection angle
        yield return new WaitWhile(() => loaded == false);
        Player.transform.position = new Vector3(0,-100,0);
        Predator.transform.position = new Vector3(100,0,0);
        Assert.That(FOVScript.IsPlayerInCone(Player.transform.position), Is.False);
    }

    [UnityTest]
    public IEnumerator TestInDetectionCone() {
        // Position of player for test depends on enemy detection angle
        yield return new WaitWhile(() => loaded == false);
        Player.transform.position = new Vector3(0,300,0);
        Predator.transform.position = new Vector3(100,300,0);
        Predator.transform.localScale = new Vector3(-Predator.transform.localScale.x, Predator.transform.localScale.y ,Predator.transform.localScale.z);
        Assert.That(FOVScript.IsPlayerInCone(Player.transform.position), Is.True);
    }

    [UnityTest]
    public IEnumerator TestLineOfSightNotOccluded() {
        // Position of player for test depends on enemy detection angle
        yield return new WaitWhile(() => loaded == false);
        Player.transform.position = new Vector3(0,300,0);
        Predator.transform.position = new Vector3(100,300,0);
        yield return new WaitForFixedUpdate();
        Assert.That(FOVScript.IsPlayerVisible(), Is.True);
    }

    [UnityTest]
    public IEnumerator TestLineOfSightOccluded() {
        // Position of player for test depends on enemy detection angle
        yield return new WaitWhile(() => loaded == false);
        Player.transform.position = new Vector3(50,10,0);
        Predator.transform.position = new Vector3(-50,-5,0);
        yield return new WaitForFixedUpdate();
        Assert.That(FOVScript.IsPlayerVisible(), Is.False);
    }

    [OneTimeTearDown]
    public void TearDown() {
        SceneManager.sceneLoaded -= OceanOnSceneLoaded;
        SceneManager.sceneLoaded -= SetEnemyFOVTestRefs;
    }
}