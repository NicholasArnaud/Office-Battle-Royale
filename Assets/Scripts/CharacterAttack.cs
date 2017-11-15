using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[RequireComponent(typeof(Character))]
public class CharacterAttack : MonoBehaviour
{
    public float mAttackSpeed;
    public float mAttackDelay;    
    public string mAttackAxis;        

    void Update()
    {
        if (Input.GetButtonDown(mAttackAxis))
        {
            CharacterEvent.Event.mCharacterAttacked.Invoke(this.GetComponent<Character>());
        }
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(CharacterAttack))]
[CanEditMultipleObjects]
class JumpControlsCheck : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CharacterAttack myScript = (CharacterAttack)target;
        if (GUILayout.Button("Check Axis Names"))
        {
            IsAxisAvailable(myScript.mAttackAxis, "mAttackAxis");
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