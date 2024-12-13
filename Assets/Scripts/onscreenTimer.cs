using System.Collections;
using UnityEngine;

//perhaps change this to a despawn trigger instead of a static timer?
public class OnscreenTimer : MonoBehaviour
{
    public float timeOnScreen;

    void Awake()
    {
        StartCoroutine(TextboxDespawnDelay());
    }

    private IEnumerator TextboxDespawnDelay()
    {
        yield return new WaitForSecondsRealtime(timeOnScreen);
        this.gameObject.SetActive(false);
    }
}
