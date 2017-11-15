using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
