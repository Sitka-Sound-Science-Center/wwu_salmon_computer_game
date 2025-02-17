using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public float DetectionRadius;
    public float ViewAngle; // in degrees, breadth of FOV cone
    public LayerMask PlayerMask; // layer that only has player object on it

    // Used for editor script
    public Vector3 GetPredatorDirection() {
        PredatorMovement pm = gameObject.GetComponent<PredatorMovement>();
        return pm.Direction;
    }

    // Helper method to vectors and angles
    public Vector3 DirectionFromAngle(float angleInDegrees) {
        float orientation = (gameObject.transform.localScale.x < 0) ? -1 : 1; // make vision cone come out of front of enemy
        angleInDegrees *= Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(angleInDegrees),Mathf.Sin(angleInDegrees),0);
        direction = Vector3.Normalize(direction);
        return direction * orientation;
    }

    public bool IsPlayerInCone(Vector3 PlayerPosition) {
        Vector3 DirectionToPlayer = PlayerPosition - gameObject.transform.position;
        bool in_radius = DirectionToPlayer.magnitude <= DetectionRadius;
        Vector3 EnemyLookDirection = GetPredatorDirection();
        DirectionToPlayer.Normalize();
        // Check if player object is inside of the enemy's vision cone
        float AngleToPlayer = Vector3.Angle(EnemyLookDirection, DirectionToPlayer);   
        if (AngleToPlayer > ViewAngle/2 || !in_radius) return false;
        return true;
    }

    // Check if player object is inside the vision cone and enemy has line of sight to player
    public bool IsPlayerVisible() {
        GameObject Player = GameObject.FindWithTag("Player");
        if (!IsPlayerInCone(Player.transform.position)) return false;
        int mask = LayerMask.GetMask(LayerMask.LayerToName(Player.layer));
        // Ray cast for objects that player can hide from enemies in 
        Vector3 DirectionToPlayer = Player.transform.position - gameObject.transform.position;
        RaycastHit2D HitInfo;
        Vector2 DirToPlayer = new Vector2(DirectionToPlayer.x, DirectionToPlayer.y);
        DirToPlayer = DirToPlayer.normalized;
        Vector2 RaycastOrigin = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        HitInfo = Physics2D.Raycast(RaycastOrigin, DirToPlayer, DetectionRadius, mask);
        // There should be an easier way to check if the object that the ray cast hits is the player object but apparently
        // GameObject class doesnt support (GameObject a == GameObject b)?
        if (HitInfo.collider != null && HitInfo.transform.gameObject.name == "Fish_Player_prefab"){
            return true;
        } 
        return false;
    }
}