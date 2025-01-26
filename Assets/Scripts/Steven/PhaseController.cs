using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(string))]

public class PhaseController : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerCamera;
    public SpawnPoints sp;
    //private GameObject CurrentPhase;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Ocean")
            ManagePhase.SetPhase(ManagePhase.Phase.Adult);
        else if (SceneManager.GetActiveScene().name == "Spawning")
            ManagePhase.SetPhase(ManagePhase.Phase.Spawning);
        else
        {
            SetActiveSprite(ManagePhase.currentPhase.ToString());
            sp.Spawn(ManagePhase.currentPhase);
        }
        
    }

    public void ChangePhase(ManagePhase.Phase nextPhase)
    {
        print("change phase reached");
        switch (nextPhase)
        {
            case ManagePhase.Phase.Alevin:
                print("why are you changing to alevin...?");
                PlayerCamera.GetComponent<Camera>().orthographicSize = 32;
                SetActiveSprite("Alevin");
                break;
            case ManagePhase.Phase.Fry:
                print("Changing to Fry");
                SetActiveSprite("Fry");
                //PlayerCamera.GetComponent<CameraXTrack>().ChangeToFryPosition();
                PlayerCamera.GetComponent<Camera>().orthographicSize = 50;
                break;
            case ManagePhase.Phase.Smolt:
                SetActiveSprite("Smolt");
                PlayerCamera.GetComponent<Camera>().orthographicSize = 70;
                break;
            default:
                print("something went wrong in phase changer");
                break;
        }
    }

    // sets all phases inactive except given phase
    private void SetActiveSprite(string phase)
    {
        GameObject child;
        for (int i = 0; i < transform.childCount; i++)
        {
            child = transform.GetChild(i).gameObject;
            transform.GetChild(i).gameObject.SetActive(child.name == phase);

        }
    }

    /*private void SetPhase(string phase) {
        // change these two GameObjects to be references in the controller 
        // or use findwithtag or similar not Find()
        string phaseCurrent = ManagePhase.currentPhase.ToString();
        GameObject currentPhase = transform.Find(phaseCurrent).gameObject; 
        GameObject nextPhase = transform.Find(phase).gameObject;
        currentPhase.SetActive(false);
        phaseCurrent = phase;
        nextPhase.SetActive(true);
        phaseCurrent = phase;
    } */
}
