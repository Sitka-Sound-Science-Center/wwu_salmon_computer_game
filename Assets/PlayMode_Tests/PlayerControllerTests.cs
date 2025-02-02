using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class PlayerControllerTests : MonoBehaviour 
{
    public GameObject Player;
    public GameObject HungerMeter;
    public GameObject FoodSpawner;
    public GameObject Predators;
    public RectTransform rt;
    public PlayerController PlayerScript;
    public FoodController FoodScript;
    public bool loaded=false;

    void ControllerOnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (SceneManager.GetActiveScene().name == "River") loaded = true;
    }

    void SetPlayerControllerTestRefs(Scene scene, LoadSceneMode mode) {
        Player = GameObject.FindWithTag("Player");
        PlayerScript = Player.GetComponentInParent<PlayerController>();
        HungerMeter = GameObject.FindWithTag("HMeter");
        Predators = GameObject.FindWithTag("PredatorsParent"); // actual enemy objects are children of this
        FoodSpawner = GameObject.FindWithTag("Spawner"); // this should be the Plankton spawner 
        FoodScript = FoodSpawner.GetComponent<FoodController>(); // so we can access the actual food 
        FoodScript.MaxFoodObjects=1; // so the test doesn't spawn a bunch of stuff
        rt = HungerMeter.GetComponent<RectTransform>();
        print(Player.name);
    }

    [OneTimeSetUp]
    public void Init() {
        SceneManager.sceneLoaded += ControllerOnSceneLoaded;
        SceneManager.sceneLoaded += SetPlayerControllerTestRefs;

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
            Assert.That(sc.activeSelf, Is.True);
        }
        UnityEngine.Time.timeScale = 1;
    }

    [UnityTest]
    public IEnumerator TestFoodCollisionHealth() {
        yield return new WaitWhile(() => loaded == false);
        float curWidth = rt.rect.width;
        Player.transform.position = FoodSpawner.transform.GetChild(0).position; // move player to food object
        yield return new WaitForFixedUpdate();
        Assert.That(rt.rect.width, Is.GreaterThan(curWidth)); // check width of health bar
    }

    [UnityTest]
    public IEnumerator TestEnemyCollisionNoDeath() {
        yield return new WaitWhile(() => loaded == false);
        float testWidth = 300;
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, testWidth); // set health so we dont die
        Player.transform.position = Predators.transform.GetChild(0).GetChild(0).position; // move player to salmon shark
        yield return new WaitForFixedUpdate();
        Predators.SetActive(false);
        Assert.That(rt.rect.width, Is.LessThan(testWidth)); // check width of health bar
        UnityEngine.Time.timeScale = 1;
        
    }

    [OneTimeTearDown]
    public void TearDown() {
        SceneManager.sceneLoaded -= ControllerOnSceneLoaded;
        SceneManager.sceneLoaded -= SetPlayerControllerTestRefs;
    }
}