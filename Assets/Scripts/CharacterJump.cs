using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(CharacterMovement))]
public class CharacterJump : MonoBehaviour
{
    public float mJumpForce;
    public string mJumpAxis;
    public bool mIsGrounded;

    void Awake()
    {
        mIsGrounded = false;
    }

    void Update()
    {
        mIsGrounded = CheckGrounded();

        if (Input.GetButtonDown(mJumpAxis) && mIsGrounded)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * mJumpForce);            
        }
    }

    bool CheckGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit))
        {
            if (hit.transform.GetComponent<Collider>())
            {
                if (Vector3.Distance(hit.point,
                        transform.position) <= transform.lossyScale.y / 2)
                {
                    return true;
                }
            }
        }
        return false;
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(CharacterJump))]
[CanEditMultipleObjects]
class AttackControlsCheck : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CharacterJump myScript = (CharacterJump)target;
        if (GUILayout.Button("Check Axis Names"))
        {
            IsAxisAvailable(myScript.mJumpAxis, "mJumpAxis");
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
            if (axis != "")
                Debug.LogWarning(property + "'s value of " + axis +
                                 " is not set up in the input manager.");
            else
                Debug.LogWarning("Assign an axis for the property " + property + ".");
        }
    }
}
#endif
