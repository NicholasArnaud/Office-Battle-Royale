using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public List<GameObject> mLookAtTargets;
    public Vector3 mFocusPoint;

    void CalculateFocusPoint()
    {
        Vector3 sumOfPositions = Vector3.zero;
        foreach (var positions in mLookAtTargets)
        {
            sumOfPositions += positions.transform.position;
        }
        mFocusPoint = sumOfPositions / (mLookAtTargets.Count - 1);
    }

    void Update()
    {
        CalculateFocusPoint();
        transform.position = new Vector3(mFocusPoint.x, transform.position.y, mFocusPoint.z);
    }
}
