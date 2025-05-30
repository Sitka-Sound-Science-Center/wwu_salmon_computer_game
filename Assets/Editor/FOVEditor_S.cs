using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if UNITY_EDITOR

[CustomEditor(typeof (EnemyFOV_S))]
public class FOVEditor_S : Editor
{
    void OnSceneGUI() {
        EnemyFOV_S fov = target as EnemyFOV_S;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.left, 360, fov.DetectionRadius, 2F);
        Vector3 PredatorDirection = fov.GetPredatorDirection();
        Vector3 BottomView = fov.DirectionFromAngle(fov.gameObject.transform.eulerAngles.z - fov.ViewAngle/2);
        Vector3 TopView = fov.DirectionFromAngle(fov.gameObject.transform.eulerAngles.z + fov.ViewAngle/2);
        Vector3 Bottom = fov.transform.position + (BottomView * fov.DetectionRadius);
        Vector3 Top = fov.transform.position + (TopView * fov.DetectionRadius);
        Vector3 dir = fov.transform.position + (PredatorDirection * fov.DetectionRadius);
        Handles.DrawLine(fov.transform.position,Bottom, 2F);
        Handles.DrawLine(fov.transform.position, Top, 2F);
        Handles.DrawLine(fov.transform.position, dir, 2F);
    }
}

#endif
