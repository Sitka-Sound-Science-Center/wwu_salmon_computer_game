using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class RiverDeathTests : MonoBehaviour 
{
    // TODO rename this to be a player controller test suite
    public GameObject Player;
    public GameObject HungerMeter;
    public GameObject FoodSpawner;
    public RectTransform rt;
    public PlayerController PlayerScript;
    public FoodController FoodScript;
    public bool loaded=false;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        loaded = true;
    }

    void SetTestRefs(Scene scene, LoadSceneMode mode) {
        Player = GameObject.FindWithTag("Player");
        PlayerScript = Player.GetComponent<PlayerController>();
        HungerMeter = GameObject.FindWithTag("HMeter");
        FoodSpawner = GameObject.FindWithTag("Spawner"); // this should be the Plankton spawner 
        FoodScript = FoodSpawner.GetComponent<FoodController>(); // so we can access the actual food 
        FoodScript.MaxFoodObjects=1;
        rt = HungerMeter.GetComponent<RectTransform>();
    }

    [OneTimeSetUp]
    public void Init() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneLoaded += SetTestRefs;

        // Only guarantees full scene load on next frame so tests must wait 
        SceneManager.LoadScene("River", LoadSceneMode.Single);
    } 

    [UnityTest]
    public IEnumerator TestKillPlayer() {
        yield return new WaitWhile(() => loaded == false);
        string[] reasons = {"BaldEagle", "SlimySculpin", "SalmonShark", "Boot"};
        foreach(string reason in reasons) {
            GameObject sc = GameObject.Find("UICanvas/DeathScreens/" + reason);
            PlayerScript.killPlayer(reason);
            Assert.That(UnityEngine.Time.timeScale, Is.EqualTo(0));
            Assert.That(sc.activeSelf, Is.True);
        }
        UnityEngine.Time.timeScale = 1;
    }

    [UnityTest]
    public IEnumerator TestFoodCollision() {
        yield return new WaitWhile(() => loaded == false);
        float curWidth = rt.rect.width;
        Player.transform.position = FoodSpawner.transform.GetChild(0).position; // move player to food object
        yield return new WaitForFixedUpdate();
        Assert.That(FoodScript.FoodObjectCount, Is.EqualTo(0)); // check food object count
        Assert.That(rt.rect.width, Is.GreaterThan(curWidth)); // check width of health bar
        FoodScript.MaxFoodObjects=10; // reset changes made during test
    }

    // TODO TEST FOR THE SECOND COLLISION METHOD FOR PREDATORS

    // TODO MAKE TEST SUITE TEARDOWNS SO WE CAN USE "RUN ALL" IN THE TEST RUNNER WINDOW
}