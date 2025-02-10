using UnityEngine;

public class EatableObject : MonoBehaviour
{
    [SerializeField]
    private float RestoreValue=0.125F; // what proportion of the meter is refilled, in [0,1]
    public GameObject Spawner;
    //private float MaxFill=550; // actual width of parent container
    //private float ActualRestore;

    public float GetRestoreValue() {
        return RestoreValue;
    }

    void Start() {
        Spawner = GameObject.FindWithTag("Spawner");
        //ActualRestore = RestoreValue*MaxFill;
    }
}