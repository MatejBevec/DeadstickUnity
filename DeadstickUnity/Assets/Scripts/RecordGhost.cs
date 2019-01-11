using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordGhost : MonoBehaviour
{
    public Record record;
    private bool recording;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Begin()
    {
        recording = true;
        record = new Record();
    }

    public void Stop()
    {
        recording = false;
        if (record != null) { Debug.Log("Tracking stopped, " + record.length + " frames recorded."); }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //check if this is fine with pointer stuff
        if (recording)
        {
            Vector3 p = transform.position;
            Quaternion r = transform.rotation;
            record.addFrame(p,r);
            //Debug.Log(p+", "+r);
        }
    }

}
