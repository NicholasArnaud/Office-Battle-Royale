using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(Character), typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    public float mMovementSpeed;
    public float mRotationSpeed;
    public string mHorizontalAxis;
    public string mVerticalAxis;
    public string mRotationAxis;
}

#if UNITY_EDITOR
[CustomEditor(typeof(CharacterMovement))]
[CanEditMultipleObjects]
class ControlsCheck : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CharacterMovement myScript = (CharacterMovement) target;
        if (GUILayout.Button("Check Axis Names"))
        {
            IsAxisAvilable(myScript.mRotationAxis);
            IsAxisAvilable(myScript.mHorizontalAxis);
            IsAxisAvilable(myScript.mVerticalAxis);
        }
    }

    void IsAxisAvilable(string axis)
    {        
            Input.GetAxis(axis);        
    }
}
#endif
