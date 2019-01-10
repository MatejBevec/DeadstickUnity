using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zaveterjeScript : MonoBehaviour
{
    public GameObject drugiAvioncl;
    public avionclMovement drugiAvionclScript;
    public float oduzetDragPower;
    private float novDragPower;
    public Terrain teren;
    public GameObject otherAvionclCube;


    void Start()
    {
        novDragPower = drugiAvionclScript.dragPower - oduzetDragPower;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == otherAvionclCube.name)
        {
            Debug.Log(other.gameObject.name);
            drugiAvionclScript.dragPower = novDragPower;
        }
    }



}

