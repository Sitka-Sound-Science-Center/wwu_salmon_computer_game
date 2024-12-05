using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class TestSuite
{
    GameObject playerPrefab = Resources.Load<GameObject>("Fish_Player_prefab");
    GameObject JoyStick = Resources.Load<GameObject>("ControlCanvas");
    
    
    // A Test behaves as an ordinary method
    [Test]
    public void TestSuiteSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestSuiteWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [Test]
    public void PlayerMovementSpeedTest()
    {
        Vector3 playerPos = Vector3.zero;
        Quaternion playerDir = Quaternion.identity;
        GameObject player = GameObject.Instantiate(playerPrefab, playerPos, playerDir);
        float movespeed = player.GetComponent<PlayerController>().getPlayerSpeed();
        Assert.That(movespeed, Is.EqualTo(1f));
    }
    [Test]
    public void JoystickCanvasSize()
    {
        Vector2 targetSize = new Vector2(1920, 1080);
        GameObject testStick = GameObject.Instantiate(JoyStick);
        Vector2 size = testStick.GetComponent<CanvasScaler>().referenceResolution;
        Assert.That(size, Is.EqualTo(targetSize));
    }

    [Test]

    public void JoystickInputPath()
    {
        //string path = "<Gamepad>/leftStick";
        GameObject testStick = GameObject.Instantiate(JoyStick);
    }

}
