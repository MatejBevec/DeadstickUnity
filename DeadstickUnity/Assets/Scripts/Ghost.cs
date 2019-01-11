using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    //public List<Vector3> positions;
    //public List<Quaternion> rotations;
    public Record record;
    private int frame;

    // Start is called before the first frame update
    void Start()
    {
        frame = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        //until the record exists, follow it
        if (record != null && frame < record.positions.Count && record.positions[frame] != null && record.rotations[frame] != null) {
            transform.position = record.positions[frame];
            transform.rotation = record.rotations[frame];
            frame++;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
