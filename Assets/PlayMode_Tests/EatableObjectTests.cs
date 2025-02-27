using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class EatableObjectTests : MonoBehaviour
{
    public GameObject Plankton;
    public EatableObject FoodScript;
    public bool loaded=false;

    void EatableOnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (SceneManager.GetActiveScene().name == "River") loaded = true;
    }

    void SetEatableTestRefs(Scene scene, LoadSceneMode mode) {
        Plankton = Resources.Load("plankton") as GameObject;
        FoodScript = Plankton.GetComponent<EatableObject>();
    }

    [OneTimeSetUp]
    public void Init() {
        SceneManager.sceneLoaded += EatableOnSceneLoaded;
        SceneManager.sceneLoaded += SetEatableTestRefs;

        // Only guarantees full scene load on next frame so tests must wait 
        SceneManager.LoadScene("River", LoadSceneMode.Single);
    } 

    [UnityTest]
    public IEnumerator TestHealthGetter() {
        yield return new WaitWhile(() => loaded == false);
        Assert.That(FoodScript.GetRestoreValue(), Is.EqualTo(0.05F));
        SceneManager.sceneLoaded -= SetEatableTestRefs;
    }
}