using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

//[RequireComponent(typeof(string))]

public class PhaseController : MonoBehaviour
{
    [SerializeField]
    private GameObject PlayerCamera;
    public SpawnPoints sp;
    private HungerMeter hungerMeter;
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
        hungerMeter = GameObject.FindWithTag("HMeter").GetComponent<HungerMeter>();
    }

    public void ChangePhase(ManagePhase.Phase nextPhase)
    {
        print("change phase reached");
        switch (nextPhase)
        {
            case ManagePhase.Phase.Alevin:
                print("why are you changing to alevin...?");
                StartCoroutine(SmoothZoom(32, 2));
                hungerMeter.SetMeterSize(0);
                SetActiveSprite("Alevin");
                break;
            case ManagePhase.Phase.Fry:
                print("Changing to Fry");
                SetActiveSprite("Fry");
                StartCoroutine(SmoothZoom(50, 2));
                hungerMeter.SetMeterSize(1);
                break;
            case ManagePhase.Phase.Smolt:
                SetActiveSprite("Smolt");
                StartCoroutine(SmoothZoom(70, 2));
                hungerMeter.SetMeterSize(1.5f);
                break;
            default:
                print("something went wrong in phase changer");
                break;
        }
    }

    private IEnumerator SmoothZoom(float target, float time)
    {
        float startSize = PlayerCamera.GetComponent<Camera>().orthographicSize;
        float elapsed = 0f;

        while (elapsed < time)
        {
            float size = Mathf.Lerp(startSize, target, elapsed / time);
            PlayerCamera.GetComponent<Camera>().orthographicSize = size;
            elapsed += Time.deltaTime;
            yield return null;
        }
        PlayerCamera.GetComponent<Camera>().orthographicSize = target;
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

}
