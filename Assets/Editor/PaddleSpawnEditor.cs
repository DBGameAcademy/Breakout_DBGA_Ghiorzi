using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PaddleSpawn), true)]
public class PaddleSpawnEditor : Editor
{
    private void OnSceneGUI()
    {
        PaddleSpawn spawn = (PaddleSpawn)target;

        Handles.color = Color.green;
        Handles.DrawWireArc(spawn.transform.position, Vector3.forward, Vector3.right, 360, spawn.Range);
    }
}
