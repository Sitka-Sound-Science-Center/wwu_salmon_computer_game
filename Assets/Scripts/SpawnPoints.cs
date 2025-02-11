using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public GameObject AlevinSpawn;
    public GameObject FrySpawn;
    public GameObject SmoltSpawn;
    public GameObject AdultSpawn;
    public GameObject SpawningSpawn;
    public GameObject Player;

    public GameObject tutorial;
    public Rigidbody2D boot;
    //private string[] stages = {"Alevin", "Fry", "Smolt", "Adult", "Spawning"}; // change to use the Stage enum?
    public HungerMeter hungerMeter;

    private void Start()
    {
        hungerMeter = GameObject.FindWithTag("HMeter").GetComponent<HungerMeter>();
    }

    public Vector3 Spawn(ManagePhase.Phase phase) {
        Debug.Log("Spawning " + phase.ToString());
        int idx = (int)phase; // mod player transform #childs eg adult prefab will only have one child

        GameObject active = Player.transform.GetChild(idx).gameObject;
        Vector3 PlayerPos, SpawnPos;
        SpawnPos = gameObject.transform.GetChild(idx).position; 
        Player.transform.position = SpawnPos; 
        PlayerPos = active.transform.position;

        int zoom = 32;

        if (phase != ManagePhase.Phase.Alevin)
        {
            boot.isKinematic = false;
            tutorial.SetActive(false);
            //hungerMeter.SetMeterSize(0)
        }
        if (phase == ManagePhase.Phase.Alevin)
        {
            hungerMeter.SetMeterSize(0);
        } else if (phase == ManagePhase.Phase.Fry)
        {
            zoom = 50;
            hungerMeter.SetMeterSize(1);
        } else if (phase == ManagePhase.Phase.Smolt)
        {
            zoom = 70;
            hungerMeter.SetMeterSize(1.5f);
            //hungerMeter.SetMeterSize(1);
        }

        GameObject.FindWithTag("Camera").GetComponent<Camera>().orthographicSize = zoom;

        return PlayerPos;
    }
}