using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{

    public string forward;
    public string back;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(forward))
        {
            transform.Translate(new Vector3(0f,0f,-0.5f)); ;
        }
        if (Input.GetKey(back))
        {
            transform.Translate(new Vector3(0f, 0f, 0.5f)); ;
        }
    }
}
