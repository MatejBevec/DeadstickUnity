using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordGhost : MonoBehaviour
{
    public List<Vector3> positions;
    public List<Quaternion> rotations;
    private bool recording;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Begin()
    {
        recording = true;
    }

    public void Stop()
    {
        recording = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (recording)
        {
            //check if pointers are alright !!!
            positions.Add(transform.position);
            rotations.Add(transform.rotation);
        }
    }

    public List<Vector3> getPos()
    {
        List<Vector3> p = new List<Vector3>();
        p.AddRange(positions);
        return p;
    }

    public List<Quaternion> getRot()
    {
        List<Quaternion> r = new List<Quaternion>();
        r.AddRange(rotations);
        return r;
    }
}
