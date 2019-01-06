using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{

    public bool tagged;
    public int state; //0-invisible, 1-visible, 2-active

    public Material untaggedMat;
    public Material taggedMat;

    // Start is called before the first frame update
    void Start()
    {
        tagged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (tagged)
        {
            GetComponent<Renderer>().material = taggedMat;
        }
        else
        {
            GetComponent<Renderer>().material = untaggedMat;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        tagged = !tagged;
    }
}
