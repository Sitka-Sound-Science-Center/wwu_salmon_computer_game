using UnityEngine;

public class EatableObject : MonoBehaviour
{
    [SerializeField]
    private float RestoreValue=0.1f; // what proportion of the meter is refilled, in [0,1]
    public GameObject Spawner;

    public float GetRestoreValue() {
        return RestoreValue;
    }

    void Start() {
        Spawner = GameObject.FindWithTag("Spawner");
        //ActualRestore = RestoreValue*MaxFill;
    }
}