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
    public Vector3 DirectionFromAngle(float angleInDegrees) {
        float orientation = (gameObject.transform.localScale.x < 0) ? -1 : 1; // make vision cone come out of front of enemy
        angleInDegrees *= Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(angleInDegrees),Mathf.Sin(angleInDegrees),0);
        direction = Vector3.Normalize(direction);
        return direction * orientation;
    }

    // Check if player object is within the vision radius
    public bool IsPlayerInRadius() {
        Collider2D PlayerCollider = Physics2D.OverlapCircle(gameObject.transform.position, DetectionRadius, PlayerMask);
        return PlayerCollider!=null;
    }

    // Check if player object is inside the vision cone and enemy has line of sight to player
    public bool IsPlayerVisible() {
        if (!IsPlayerInRadius()) return false;
        //print("Player entered radius: " + gameObject.name);
        GameObject Player = GameObject.FindWithTag("Player");
        Vector3 DirectionToPlayer = Player.transform.position - gameObject.transform.position;
        Vector3 EnemyLookDirection = (gameObject.transform.localScale.x < 0) ? Vector3.left : Vector3.right;
        DirectionToPlayer.Normalize();
        // Check if player object is inside of the enemy's vision cone
        float AngleToPlayer = Vector3.Angle(EnemyLookDirection, DirectionToPlayer);   
        if (AngleToPlayer > ViewAngle/2) return false;
        // Ray cast for objects that player can hide from enemies in 
        RaycastHit2D HitInfo;
        Vector2 DirToPlayer = new Vector2(DirectionToPlayer.x, DirectionToPlayer.y);
        Vector2 RaycastOrigin = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        HitInfo = Physics2D.Raycast(gameObject.transform.position, DirectionToPlayer, DetectionRadius, PlayerMask);
        // There should be an easier way to check if the object that the ray cast hits is the player object but apparently
        // GameObject class doesnt support (GameObject a == GameObject b)?
        if (HitInfo.collider != null && HitInfo.transform.gameObject.name == "Fish_Player_prefab") return true;
        return false;
    }
}