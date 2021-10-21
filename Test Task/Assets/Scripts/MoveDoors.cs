using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoors : MonoBehaviour
{

    public GameObject leftMovingDoor;

    public GameObject rightMovingDoor;

    public Vector3 leftMaximumOpening;
    public Vector3 rightMaximumOpening;

    public Vector3 leftMaximumClosing;
    public Vector3 rightMaximumClosing;

    public float movementSpeed = 2f;

    bool playerIsHere = false;
    
    // Update is called once per frame
    void Update()
    {
        if (playerIsHere)
        {
            if (leftMovingDoor.transform.position != leftMaximumOpening)
            {
                leftMovingDoor.transform.Translate(leftMaximumOpening);
            }
            if (rightMovingDoor.transform.position != rightMaximumOpening)
            {
                rightMovingDoor.transform.Translate(rightMaximumOpening);
            }
        }
        else
        {
            if (leftMovingDoor.transform.position == leftMaximumClosing)
            {
                leftMovingDoor.transform.Translate(leftMaximumClosing);
            }
            if (rightMovingDoor.transform.position == rightMaximumClosing)
            {
                rightMovingDoor.transform.Translate(rightMaximumClosing);
            }
        }


    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsHere = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsHere = false;
        }
    }
}
