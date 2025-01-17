using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (EnemyFOV))]
public class FOVEditor : Editor
{
    void OnSceneGUI() {
        EnemyFOV fov = target as EnemyFOV;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.forward, Vector3.left, 360, fov.DetectionRadius, 2F);
    }
}
