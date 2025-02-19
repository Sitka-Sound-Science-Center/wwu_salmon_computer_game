using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.TestTools;
using NUnit.Framework;

[TestFixture]
public class PredatorMovementTests : MonoBehaviour
{
    public GameObject Player;
    public GameObject OrcaWhale;
    public EnemyFOV FOVScript;
    public PredatorMovement MovementScript;
    public bool loaded=false;

    void OceanOnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (SceneManager.GetActiveScene().name == "Ocean") loaded = true;
    }

    void SetPredatorMovementTestRefs(Scene scene, LoadSceneMode mode) {
        Player = GameObject.FindWithTag("Player");
        OrcaWhale = GameObject.Find("Predators/OrcaWhale");
        MovementScript = OrcaWhale.GetComponent<PredatorMovement>();
        FOVScript = OrcaWhale.GetComponent<EnemyFOV>();
    }

    [OneTimeSetUp]
    public void Init() {
        SceneManager.sceneLoaded += OceanOnSceneLoaded;
        SceneManager.sceneLoaded += SetPredatorMovementTestRefs;

        // Only guarantees full scene load on next frame so tests must wait 
        SceneManager.LoadScene("Ocean", LoadSceneMode.Single);
    } 

    [UnityTest]
    public IEnumerator TestLeftOrientationScale() {
        yield return new WaitWhile(() => loaded == false);
        MovementScript.SetSpriteOrientation(Vector3.left);
        Assert.That(OrcaWhale.transform.localScale.x, Is.LessThan(0));
    }

    [UnityTest]
    public IEnumerator TestRightOrientationScale() {
        yield return new WaitWhile(() => loaded == false);
        MovementScript.SetSpriteOrientation(Vector3.right);
        Assert.That(OrcaWhale.transform.localScale.x, Is.GreaterThanOrEqualTo(0));
    }

    [UnityTest]
    public IEnumerator TestLeftOrientationRotation() {
        yield return new WaitWhile(() => loaded == false);
        MovementScript.SetSpriteOrientation(Vector3.left);
        Assert.That(OrcaWhale.transform.eulerAngles.z, Is.EqualTo(0));
    }

    [UnityTest]
    public IEnumerator TestRightOrientationRotation() {
        yield return new WaitWhile(() => loaded == false);
        MovementScript.SetSpriteOrientation(Vector3.right);
        Assert.That(OrcaWhale.transform.eulerAngles.z, Is.EqualTo(0));
    }

    [UnityTest]
    public IEnumerator TestLeftOrientationGeneralRotation() {
        yield return new WaitWhile(() => loaded == false);
        OrcaWhale.transform.localScale = new Vector3(-OrcaWhale.transform.localScale.x, OrcaWhale.transform.localScale.y, OrcaWhale.transform.localScale.z);
        Vector3 dir = FOVScript.DirectionFromAngle(-45); 
        MovementScript.SetSpriteOrientation(dir);
        Assert.That(OrcaWhale.transform.eulerAngles.z, Is.EqualTo(315));
    }

    [UnityTest]
    public IEnumerator TestLeftOrientationGeneralRotation2() {
        yield return new WaitWhile(() => loaded == false);
        OrcaWhale.transform.localScale = new Vector3(-OrcaWhale.transform.localScale.x, OrcaWhale.transform.localScale.y, OrcaWhale.transform.localScale.z);
        Vector3 dir = FOVScript.DirectionFromAngle(-87); 
        MovementScript.SetSpriteOrientation(dir);
        Assert.That(OrcaWhale.transform.eulerAngles.z, Is.EqualTo(273));
    }

    [UnityTest]
    public IEnumerator TestRightOrientationGeneralRotation() {
        yield return new WaitWhile(() => loaded == false);
        Vector3 dir = FOVScript.DirectionFromAngle(67); 
        MovementScript.SetSpriteOrientation(dir);
        Assert.That(OrcaWhale.transform.eulerAngles.z, Is.EqualTo(67));
    }

    [OneTimeTearDown]
    public void TearDown() {
        SceneManager.sceneLoaded -= OceanOnSceneLoaded;
        SceneManager.sceneLoaded -= SetPredatorMovementTestRefs;
    }
}