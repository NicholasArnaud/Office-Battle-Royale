using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Character : MonoBehaviour
{
    public string mName;
    public float mMovementSpeed;



    void Awake()
    {
#if UNITY_EDITOR
        if (mName == "")
            mName = "Default";
        if (mMovementSpeed == 0)
            mMovementSpeed = 1;
#endif        
        Assert.IsTrue(mName == "", "Character has no name.");
        Assert.IsTrue(mMovementSpeed == 0, "Movement speed not set");
    }
}
