using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{

    public bool clickToPick;
    public float distanceToClick;
    [Range(000, 999)]
    public int ID;

    private void OnEnable()
    {
        EventManager.OnClicked += PickUp;
    }
    private void OnDisable()
    {
        EventManager.OnClicked -= PickUp;
    }

    private void Start()
    {
        Collider collider = gameObject.GetComponent<Collider>();
        if (!clickToPick)
            collider.isTrigger = true;
        else
            collider.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!clickToPick)
        {
            if (other.tag == "Player")
            {
                PickUp();
            }
        }
    }
    private void OnMouseDown()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        if (clickToPick)
        {
            float distance = Vector3.Distance(player.position, gameObject.transform.position);
            if (distanceToClick >= distance)
            {
                PickUp();
            }
        }
    }

    public void PickUp()
    {
        Debug.Log("Pick Up");
    }
}
