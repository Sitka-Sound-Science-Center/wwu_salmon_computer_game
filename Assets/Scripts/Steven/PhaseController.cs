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
    private GameObject CurrentPhase;
    private ManagePhase mp;
    // Start is called before the first frame update
    void Start()
    {
        mp = GameObject.FindWithTag("SpawnPoints").GetComponent<ManagePhase>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // some sort of GetNextPhase(CurrentPhase) instead?
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
                mp.SetStage(ManagePhase.Stage.Fry);
                break;
            case "Smolt":
                setPhase("Smolt");
                mp.SetStage(ManagePhase.Stage.Smolt);
                break;
            default:
                print("something went wrong in phase changer");
                break;
        }
    }

    private void setPhase(string phase) {
        // change these two GameObjects to be references in the controller 
        // or use findwithtag or similar not Find()
        GameObject currentPhase = this.transform.Find(phaseCurrent).gameObject; 
        GameObject nextPhase = this.transform.Find(phase).gameObject;
        currentPhase.SetActive(false);
        phaseCurrent = phase;
        nextPhase.SetActive(true);
        phaseCurrent = phase;
    }
}
