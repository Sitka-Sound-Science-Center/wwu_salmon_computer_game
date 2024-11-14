using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaysToDie : MonoBehaviour
{
    [SerializeField]
    private int crushTime;
    private bool timedOut;
    private bool beingCrushed;
    // Start is called before the first frame update
    void Start()
    {
        timedOut = false;
        beingCrushed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //Boot Crusher collider
        if (collision.gameObject.CompareTag("Crusher"))
        {
            print("CrusherDetected");
            timedOut = false;
            beingCrushed = true;
            StartCoroutine("crushTimer");
            if (timedOut && beingCrushed)
            {
                print("Show Kill Screen");
                
                print("Cause Of Death" + collision.gameObject.name);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Crusher"))
        {
            beingCrushed = false;
        }   
    }

    IEnumerable crushTimer()
    {
        print("waiting...)");
        yield return new WaitForSeconds(crushTime);
        timedOut = true;
        print("returning");
    }
}
