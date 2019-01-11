using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public List<Vector3> positions;
    public List<Quaternion> rotations;
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
        if (positions[frame] != null && rotations[frame] != null) {
            transform.position = positions[frame];
            transform.rotation = rotations[frame];
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
