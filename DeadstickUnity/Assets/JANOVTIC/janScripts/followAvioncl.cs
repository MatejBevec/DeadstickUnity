using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followAvioncl : MonoBehaviour
{
    public Transform avioncl;
    public Vector3 offset;
    public float bias; //percent to move towards new destination
    public float up;
    public float back;
    public float CamForward;

    void Update()
    {
        offset = avioncl.position - avioncl.forward * back + Vector3.up * up;
        this.transform.position = this.transform.position * bias + offset * (1f - bias);
        this.transform.LookAt(avioncl.position + avioncl.forward * CamForward);
    }
}
