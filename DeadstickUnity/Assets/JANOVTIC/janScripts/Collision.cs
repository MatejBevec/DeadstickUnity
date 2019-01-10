using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public followAvioncl followAvioncl;
    public aViewFromHeaven aViewFromHeaven;
    public avionclMovement scriptMovement;
    public TorpedoMovement torpedoMovement;
    public TorpedoMovement torpedoMovement2;
    public Rigidbody rg;
    public float kamGaOdfuka;
    private bool permission = true;
    public AudioManager audioManager;
    public GameObject explosionEffect;


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (permission&&collision.collider.tag == "Ovira")
        {
            scriptMovement.thrustLevel = 0;
            followAvioncl.enabled = false;
            aViewFromHeaven.enabled = true;
            scriptMovement.enabled = false;
            if (torpedoMovement != null)
            {
                torpedoMovement.enabled = false;
                torpedoMovement2.enabled = false;
            }
            //AVIONCL.EXPLODE!!!!!!
            rg.useGravity = true;
            audioManager.playExplosion();
            rg.AddForce(scriptMovement.thrust * scriptMovement.speed * scriptMovement.speed / kamGaOdfuka);
            Explode();
            permission = false;
        }
    }

        

        private void Explode()
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
        Debug.Log("AvionclExplodiru");
        }
    }