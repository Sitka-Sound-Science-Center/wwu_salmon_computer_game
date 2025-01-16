using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float DetectionRadius;
    public float ViewAngle; // in radians, breadth of FOV cone
    public LayerMask ObjectsMask;
    public LayerMask PlayerMask; // layer that only has player object on it

    public Vector3 DirectionFromAngle(float angle) {
        return new Vector3(Mathf.Cos(angle),Mathf.Sin(angle),0); // should this be vec2 or have trig values swapped?
    }

    public bool IsPlayerInRadius() {
        Collider2D PlayerCollider = Physics2D.OverlapCircle(gameObject.transform.position, DetectionRadius, PlayerMask);
        return PlayerCollider == null;
    }

    public bool IsPlayerVisible(Vector3 ToPlayer) {
        if (!IsPlayerInRadius()) return false;
        Collider2D[] ObjectsInViewRadius = Physics2D.OverlapCircleAll(gameObject.transform.position, DetectionRadius, ObjectsMask);
        

        // ignore occlusion -- check if ray hits something else before player
        // if vector to player is facing away from vision cone return false
        // if vector to player is outside of vision cone return false
        // otherwise return true 
    }
}
