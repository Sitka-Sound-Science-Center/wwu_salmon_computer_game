using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float DetectionRadius;
    public float ViewAngle; // in degrees, breadth of FOV cone
    public LayerMask ObjectsMask;
    public LayerMask PlayerMask; // layer that only has player object on it

    // Helper method to vectors and angles
    public Vector3 DirectionFromAngle(float angle) {
        return new Vector3(Mathf.Cos(angle),Mathf.Sin(angle),0); // should this be vec2 or have trig values swapped?
    }

    // Check if player object is within the vision radius
    public bool IsPlayerInRadius() {
        Collider2D PlayerCollider = Physics2D.OverlapCircle(gameObject.transform.position, DetectionRadius, PlayerMask);
        return PlayerCollider != null;
    }

    // Check if player object is inside the vision cone and enemy has line of sight to player
    public bool IsPlayerVisible() {
        print(gameObject.name);
        if (!IsPlayerInRadius()) {
            print("Player not in radius");
            return false;
        } 
        print("Player entered radius: " + gameObject.name);
        GameObject Player = GameObject.FindWithTag("Player");
        Vector3 DirectionToPlayer = Player.transform.position - gameObject.transform.position;
        print("Distance to player: " + DirectionToPlayer.magnitude + "(" + gameObject.name + ")");
        DirectionToPlayer.Normalize();
        // Check if player object is inside of the enemy's vision cone
        float AngleToPlayer = Vector3.Angle(gameObject.transform.forward, DirectionToPlayer);   
        if (AngleToPlayer > ViewAngle/2) return false;
        // Do a ray cast to check if player is occluded by something ? 
        print("Player in cone");
        return true;
    }
}
