using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aViewFromHeaven : MonoBehaviour
{
    public Transform avioncl; 
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = avioncl.position + offset;
        this.transform.LookAt(avioncl.position);
    }
}
