using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record
{
    public List<Vector3> positions;
    public List<Quaternion> rotations;
    public int length;

    public Record()
    {
        positions = new List<Vector3>();
        rotations = new List<Quaternion>();
        length = 0;
    }

    public void addFrame(Vector3 pos, Quaternion rot)
    {
        positions.Add(pos);
        rotations.Add(rot);
        length++;
    }
}
