using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{

    private bool tagged;

    public Material untaggedMat;
    public Material taggedMat;

    //don't wanna do this - link to RingManager
    public RingManager myManager;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Ring>().enabled = true;
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

    public void Tag()
    {
        tagged = true;
        GetComponent<Renderer>().material = taggedMat;
    }

    public void Untag()
    {
        GetComponent<Renderer>().material = untaggedMat;
        tagged = false;
    }

    public void ToggleTag()
    {
        if (tagged) { Untag(); }
        else if (!tagged) { Tag(); }
   
    }

    //looks like i'll have to communicate upstream :(
    void OnTriggerEnter(Collider other)
    {
        if (myManager != null)
        {
            Debug.Log("Collision detected.");
            myManager.RingCollided(gameObject, other);
        }
        else
        {
            Debug.Log("Not linked to a RingManager.");
        }
    }
}
