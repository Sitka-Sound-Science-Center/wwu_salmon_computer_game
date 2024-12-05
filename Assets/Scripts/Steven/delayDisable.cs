using System.Collections;
using UnityEngine;

public class delayDisable : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Waitdelay());
    }

    IEnumerator Waitdelay()
    {
        yield return new WaitForSeconds(3);
        gameObject.GetComponentInParent<Transform>().gameObject.SetActive(false);
    }
}
