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
    public GameObject Player;
    public GameObject HungerMeter;
    private RectTransform rt;
    public PlayerController PlayerScript;
    public bool loaded=false;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        loaded = true;
    }

    void SetTestRefs(Scene scene, LoadSceneMode mode) {
        Player = GameObject.FindWithTag("Player");
        PlayerScript = Player.GetComponent<PlayerController>();
        HungerMeter = GameObject.FindWithTag("HMeter");
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
        // instantiate food object
        // move player to food object
        // collide
        // check food object count
        // check width of health bar
    }
}