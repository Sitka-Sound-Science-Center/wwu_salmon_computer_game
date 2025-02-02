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
    public GameObject OrcaWhale;
    public EnemyFOV FOVScript;
    public PredatorMovement MovementScript;
    public bool loaded=false;

    void OceanOnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (SceneManager.GetActiveScene().name == "Ocean") loaded = true;
    }

    void SetEnemyFOVTestRefs(Scene scene, LoadSceneMode mode) {
        Player = GameObject.FindWithTag("Player");
        OrcaWhale = GameObject.Find("Predators/AssetSpawner(fish)/OrcaWhale");
        MovementScript = OrcaWhale.GetComponent<PredatorMovement>();
        FOVScript = OrcaWhale.GetComponent<EnemyFOV>();
    }

    [OneTimeSetUp]
    public void Init() {
        SceneManager.sceneLoaded += OceanOnSceneLoaded;
        SceneManager.sceneLoaded += SetEnemyFOVTestRefs;

        // Only guarantees full scene load on next frame so tests must wait 
        SceneManager.LoadScene("Ocean", LoadSceneMode.Single);
    } 

    [UnityTest]
    public IEnumerator TestInDetectionRadius() {
        yield return new WaitWhile(() => loaded == false);
        Player.transform.position = new Vector3(0,0,0);
        OrcaWhale.transform.position = new Vector3(100,0,0);
        Assert.That(FOVScript.IsPlayerInRadius(), Is.True);
    }

    [UnityTest]
    public IEnumerator TestNotInDetectionRadius() {
        yield return new WaitWhile(() => loaded == false);
        Player.transform.position = new Vector3(0,0,0);
        OrcaWhale.transform.position = new Vector3(200,0,0);
        Assert.That(FOVScript.IsPlayerInRadius(), Is.False);
    }

    [UnityTest]
    public IEnumerator TestNotInDetectionConeTop() {
        // Position of player for test depends on enemy detection angle
        yield return new WaitWhile(() => loaded == false);
        Player.transform.position = new Vector3(0,100,0);
        OrcaWhale.transform.position = new Vector3(100,0,0);
        Assert.That(FOVScript.IsPlayerVisible(), Is.False);
    }

    [UnityTest]
    public IEnumerator TestNotInDetectionConeBottom() {
        // Position of player for test depends on enemy detection angle
        yield return new WaitWhile(() => loaded == false);
        Player.transform.position = new Vector3(0,-100,0);
        OrcaWhale.transform.position = new Vector3(100,0,0);
        Assert.That(FOVScript.IsPlayerVisible(), Is.False);
    }

    [UnityTest]
    public IEnumerator TestInDetectionCone() {
        // Position of player for test depends on enemy detection angle
        yield return new WaitWhile(() => loaded == false);
        Player.transform.position = new Vector3(0,0,0);
        OrcaWhale.transform.position = new Vector3(100,0,0);
        GameObject Seaweed = GameObject.FindWithTag("Terrain");
        Seaweed.SetActive(false);
        Assert.That(FOVScript.IsPlayerVisible(), Is.True);
    }

    [UnityTest]
    public IEnumerator TestDirectionInCone() {
        yield return new WaitWhile(() => loaded == false);
        Player.transform.position = new Vector3(0,0,0);
        OrcaWhale.transform.position = new Vector3(100,0,0);
        Vector3 DirectionToPlayer = Vector3.Normalize(Player.transform.position - OrcaWhale.transform.position);
        Assert.That(MovementScript.Direction, Is.EqualTo(DirectionToPlayer));
    }

    [OneTimeTearDown]
    public void TearDown() {
        SceneManager.sceneLoaded -= OceanOnSceneLoaded;
        SceneManager.sceneLoaded -= SetEnemyFOVTestRefs;
    }
}