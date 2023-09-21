using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WayPoint))]
public class WayPointEditor : Editor
{
    WayPoint wayPoint => target as WayPoint;

    private void OnSceneGUI()
    {
        for (int i = 0; i < wayPoint.Points.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            //create handle
            Vector3 currentWayPointPoint = wayPoint.CurrentPosition + wayPoint.Points[i];
            Vector3 newWayPointPoint = Handles.FreeMoveHandle(currentWayPointPoint, Quaternion.identity,
                0.7f, new Vector3(x: 0.3f, y: 0.3f, z: 0.3f), Handles.SphereHandleCap);

            //numbering handles
            GUIStyle numStyle = new GUIStyle();
            numStyle.fontSize = 16;
            numStyle.fontStyle = FontStyle.Bold;
            numStyle.normal.textColor = Color.magenta;
            Vector3 textAllignment = Vector3.down * 0.35f + Vector3.right * 0.35f;

            Handles.Label(wayPoint.CurrentPosition + wayPoint.Points[i] + textAllignment, text: $"{i + 1}", numStyle);

            EditorGUI.EndChangeCheck();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, name: "Free Move Handle");
                wayPoint.Points[i] = newWayPointPoint - wayPoint.CurrentPosition;
            }
        }
    }
}
