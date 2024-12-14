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
    public PlayerController PlayerScript;
    public bool loaded=false;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        loaded = true;
    }

    void SetTestRefs(Scene scene, LoadSceneMode mode) {
        PlayerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
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
}