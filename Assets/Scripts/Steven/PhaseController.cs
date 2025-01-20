using UnityEngine;

//[RequireComponent(typeof(string))]

public class PhaseController : MonoBehaviour
{
    public string phaseCurrent;
    [SerializeField]
    private GameObject PlayerCamera;
    //private GameObject CurrentPhase;

    public void ChangePhase(string nextPhase)
    {
        print("change phase reached");
        switch (nextPhase)
        {
            case "Alevin":
                print("why are you changing to alevin...?");
                PlayerCamera.GetComponent<Camera>().orthographicSize = 35;
                break;
            case "Fry":
                print("Changing to Fry");
                SetPhase("Fry");
                //PlayerCamera.GetComponent<CameraXTrack>().ChangeToFryPosition();
                PlayerCamera.GetComponent<Camera>().orthographicSize = 50;
                break;
            case "Smolt":
                SetPhase("Smolt");
                PlayerCamera.GetComponent<Camera>().orthographicSize = 70;
                break;
            default:
                print("something went wrong in phase changer");
                break;
        }
    }

    private void SetPhase(string phase) {
        // change these two GameObjects to be references in the controller 
        // or use findwithtag or similar not Find()
        GameObject currentPhase = transform.Find(phaseCurrent).gameObject; 
        GameObject nextPhase = transform.Find(phase).gameObject;
        currentPhase.SetActive(false);
        phaseCurrent = phase;
        nextPhase.SetActive(true);
        phaseCurrent = phase;
    }
}
