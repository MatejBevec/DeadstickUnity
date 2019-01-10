using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TorpedoMovement : MonoBehaviour
{

    public Rigidbody rg;
    public Transform avioncl;
    public float shootingPower;
    private Vector3 torpedoPower;
    public bool shoot = false;
    public avionclMovement scriptMovement;
    public string shootInput;
    public torpedoCollision torpedoCollision;
    Collider torpedoCollider;
    public Transform drugiAvioncl;
    



  

    public AudioManager AudioManager;

    void Start()
    {
        torpedoCollider = GetComponent<Collider>();
        torpedoCollider.isTrigger = true;
        Physics.IgnoreCollision(avioncl.GetComponent<Collider>(), GetComponent<Collider>());


    }

  

    void Update()
    {
        if (shoot||Input.GetKeyDown(shootInput))
        {

            if (!shoot)
            {

                AudioManager.playLaunch();
                transform.parent = null;
                shoot = true;
                Destroy(gameObject, torpedoCollision.secToDestroy);
                torpedoCollision.izstreljen = true;
                torpedoCollider.isTrigger = false;


            }
            fire();
            
        }
    }

    void fire()
    {
        torpedoPower = transform.forward * shootingPower * scriptMovement.speed / (scriptMovement.maxSpeed / 2);
        this.transform.LookAt(drugiAvioncl.transform.position);
        rg.AddForce(torpedoPower);
    }

   
}
