using System.Collections;
using UnityEngine;

//perhaps change this to a despawn trigger instead of a static timer?
public class OnscreenTimer : MonoBehaviour
{
    public bool shown;
    public float timeOnScreen;

    private void OnEnable() {
        if (!shown) StartCoroutine(TextboxDespawnDelay());
        else gameObject.SetActive(false);
    }

    private IEnumerator TextboxDespawnDelay() {
        yield return new WaitForSecondsRealtime(timeOnScreen);
        shown = true;
        gameObject.SetActive(false);
    }
}
