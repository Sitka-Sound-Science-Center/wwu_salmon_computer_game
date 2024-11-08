using System.Collections;
using UnityEngine;

public class delayDisable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitdelay());
        

    }

    IEnumerator waitdelay()
    {
        yield return new WaitForSeconds(3);
        gameObject.GetComponentInParent<Transform>().gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
