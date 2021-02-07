using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BabyGrabber))]
public class BabyGrabberGUI : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BabyGrabber myScript = (BabyGrabber) target;
        if(GUILayout.Button("Drop Prop"))
        {
            myScript.DropProp();
        }
    }
}
