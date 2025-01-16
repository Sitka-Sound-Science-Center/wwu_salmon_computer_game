using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float DetectionRadius;
    public float ViewAngle; // in radians, breadth of FOV cone
    public LayerMask ObjectsMask;

    public Vector3 DirectionFromAngle(float angle) {
        return new Vector3(Mathf.Cos(angle),Mathf.Sin(angle),0);
    }

    public void FindVisibleTargets() {
        Collider2D[] ObjectsInViewRadius = Physics2D.OverlapCircleAll(gameObject.transform.position, DetectionRadius, ObjectsMask);
    }
    public bool IsPlayerVisible(Vector3 ToPlayer) {
        Vector3 LowestView = DirectionFromAngle(-ViewAngle/2);
        Vector3 HighestView = DirectionFromAngle(ViewAngle/2);
        // ignore occlusion -- check if ray hits something else before player
        // if vector to player is facing away from vision cone return false
        // if vector to player is outside of vision cone return false
        // otherwise return true 
    }
}
