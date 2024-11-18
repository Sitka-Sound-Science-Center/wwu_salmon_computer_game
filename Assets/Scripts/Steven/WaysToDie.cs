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

    public void killPlayer()
    {
        //kills the player, allows for other objects to send a kill command
    }
}
