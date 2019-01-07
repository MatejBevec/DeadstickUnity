using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TorpedoMovement : MonoBehaviour
{
    public GameObject torpedo;
    public Rigidbody rg;
    public Transform avioncl;
    public float shootingPower;
    public float secToDestroy;
    public bool shoot = false;

    public AudioManager AudioManager;

    void Start()
    {
        Physics.IgnoreCollision(avioncl.GetComponent<Collider>(), GetComponent<Collider>());
    }

    void Update()
    {
        if (shoot||Input.GetKeyDown("u"))
        {

            if (!shoot)
            {
                AudioManager.playLaunch();
                transform.parent = null;
                shoot = true;
            }
            fire();
        }
    }

    void fire()
    {
        rg.AddForce(transform.up * shootingPower * avionclMovement.speed/(avionclMovement.maxStaticSpeed/2));
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (!AudioManager.explosionAlreadyPlayed)
        {

            Destroy(torpedo,secToDestroy);
            AudioManager.playExplosion();
            AudioManager.explosionAlreadyPlayed = true;
        }
    }

}
