using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zaveterjeScript : MonoBehaviour
{
    public GameObject drugiAvioncl;
    public avionclMovement drugiAvionclScript;
    public GameObject otherAvionclCube;

    private float novDragPower;
    public float oduzetDragPower;

    void Start()
    {
        novDragPower = drugiAvionclScript.dragPower - oduzetDragPower;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == otherAvionclCube.name)
        {
            drugiAvionclScript.dragPower = novDragPower;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        drugiAvionclScript.dragPower = drugiAvionclScript.nespremenjenDragPower;
    }
}

