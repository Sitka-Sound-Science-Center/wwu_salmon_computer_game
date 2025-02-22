using UnityEngine;

public class EatableObject : MonoBehaviour
{
    [SerializeField]
    private float RestoreValue=0.1f; // what proportion of the meter is refilled, in [0,1]

    public float GetRestoreValue() {
        return RestoreValue;
    }
}