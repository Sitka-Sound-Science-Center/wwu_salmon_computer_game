using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxTrigger : MonoBehaviour
{
    public GameObject textbox;
    public bool showOnStart;
    public float showForSec;

    // Start is called before the first frame update
    void Start()
    {
        textbox.SetActive(showOnStart);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textbox.SetActive(true);
            StartCoroutine(WaitToCloseBox());
        }
    }

    public IEnumerator WaitToCloseBox()
    {
        yield return new WaitForSeconds(showForSec);
        textbox.SetActive(false);
    }
}
