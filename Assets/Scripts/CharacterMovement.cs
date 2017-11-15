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

    void Update()
    {
        float rotation = Input.GetAxis(mRotationAxis) * mRotationSpeed;
        float horizontal = Input.GetAxis(mHorizontalAxis) * mMovementSpeed;
        float vertical = Input.GetAxis(mVerticalAxis) * mMovementSpeed;
        transform.Rotate(new Vector3(0,rotation,0));        
        if (GetComponent<CharacterJump>().mIsGrounded)
        {
            Vector3 directionalMovement = (transform.forward * vertical) + (transform.right * horizontal);            
            transform.TransformDirection(directionalMovement);
            GetComponent<Rigidbody>().velocity = directionalMovement;            
        }
    }
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
            IsAxisAvailable(myScript.mRotationAxis, "mRotationAxis");
            IsAxisAvailable(myScript.mHorizontalAxis, "mHorizontalAxis");
            IsAxisAvailable(myScript.mVerticalAxis, "mVerticalAxis");
        }
    }

    void IsAxisAvailable(string axis, string property)
    {
        try
        {
            Input.GetAxis(axis);
            Debug.Log(property + "'s value of " + axis + " is valid.");
        }
        catch (ArgumentException exc)
        {
            if(axis != "")
                Debug.LogWarning(property + "'s value of " + axis + 
                    " is not set up in the input manager.");
            else
                Debug.LogWarning("Assign an axis for the property " + property + ".");            
        }                
    }
}
#endif
