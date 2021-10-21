using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{

    public GameObject leftDoor;
    public GameObject rightDoor;

    Vector3 startPosLeft;
    Vector3 startPosRight;

    public Vector3 leftOffset;
    public Vector3 rightOffset;
    public float speed;

    public bool playerIsHere;
    public bool playerExitTrigger;
    // Start is called before the first frame update
    void Start()
    {
        startPosLeft = new Vector3(leftDoor.transform.position.x, leftDoor.transform.position.y, leftDoor.transform.position.z);
        startPosRight = new Vector3(rightDoor.transform.position.x, rightDoor.transform.position.y, rightDoor.transform.position.z);
        Debug.Log(startPosLeft);
        Debug.Log(startPosRight);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        if (playerIsHere)
        {
            Vector3 leftStart = new Vector3(leftDoor.transform.position.x, leftDoor.transform.position.y, leftDoor.transform.position.z);
            Vector3 rightStart = new Vector3(rightDoor.transform.position.x, rightDoor.transform.position.y, rightDoor.transform.position.z);
            leftDoor.transform.position = Vector3.Lerp(leftStart, leftOffset, speed);
            rightDoor.transform.position = Vector3.Lerp(rightStart,rightOffset, speed);
        }
        if (playerExitTrigger&&!playerIsHere)
        {
            Vector3 leftStart = new Vector3(leftDoor.transform.position.x, leftDoor.transform.position.y, leftDoor.transform.position.z);
            Vector3 rightStart = new Vector3(rightDoor.transform.position.x, rightDoor.transform.position.y, rightDoor.transform.position.z);
            leftDoor.transform.position = Vector3.Lerp(leftStart, startPosLeft, speed);
            rightDoor.transform.position = Vector3.Lerp(rightStart, startPosRight, speed);
        }

        

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsHere = false;
            playerExitTrigger = true;
        }
    }
    
}
