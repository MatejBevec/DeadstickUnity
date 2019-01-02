using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followAvioncl : MonoBehaviour
{
    public Transform avioncl;
    public Vector3 offset;
       

    // Update is called once per frame
    void Update()
    {
        transform.position = avioncl.position + offset;
    }
}
