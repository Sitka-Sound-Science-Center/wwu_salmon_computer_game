using System.Collections;
using System.Collections.Generic;
//using UnityEditor.UI;
using UnityEngine;

[RequireComponent(typeof(string))]
public class PhaseController : MonoBehaviour
{
    [SerializeField]
    private string phaseCurrent;
    [SerializeField]
    private GameObject PlayerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePhase(string nextPhase)
    {
        print("change phase reached");
        switch (nextPhase)
        {
            case "Alevin":
                print("why are you changing to alevin...?");
                break;
            case "Fry":
                print("Changing to Fry");
                setPhase("Fry");
                PlayerCamera.GetComponent<CameraXTrack>().ChangeToFryPosition();
                break;
            case "Smolt":

            default:
                print("something went wrong in phase changer");
                break;
        }
    }

    private void setPhase(string phase)
    {
        //disable current phase
        GameObject currentPhase = this.transform.Find(phaseCurrent).gameObject;
        GameObject nextPhase = this.transform.Find(phase).gameObject;

        currentPhase.SetActive(false);
        nextPhase.SetActive(true);
        //phaseCurrent = phase;
        //enable next phsae
    }
}
