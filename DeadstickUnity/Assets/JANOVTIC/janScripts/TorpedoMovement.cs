using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoMovement : MonoBehaviour
{
    
    public Rigidbody rg;
   // public Vector3 offset;
    public Transform avioncl;
    public float shootingPower;
    // Start is called before the first frame update
    public bool shoot = false;

    private void Start()
    {
        Physics.IgnoreCollision(avioncl.GetComponent<Collider>(), GetComponent<Collider>());

    }

    void Update()
    {
            if (shoot||Input.GetKeyDown("u"))
        {
            if (!shoot)
            {
                transform.parent = null;
                shoot = true;
            }
            fire();
        }
    }

    void fire()
    {

        rg.AddForce(transform.up * shootingPower);
    }

}
