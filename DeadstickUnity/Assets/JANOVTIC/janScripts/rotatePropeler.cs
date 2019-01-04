using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatePropeler : MonoBehaviour
{
  
    public GameObject Avioncl;
    // Start is called before the first frame update
    void Start()
    {
    avionclMovement avionclMovement = Avioncl.GetComponent<avionclMovement>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0f,0f,avionclMovement.speed * avionclMovement.thrustLevel);
    }
}
