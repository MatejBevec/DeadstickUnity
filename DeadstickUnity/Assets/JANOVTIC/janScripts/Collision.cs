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
    public AudioManager audioManager;
    public GameObject explosionEffect;

    public float kamGaOdfuka;//koliko ga odnese stran ko se zaleti

    private bool permission = true;


    private void OnCollisionEnter(UnityEngine.Collision collision)
    {

        //------------------------------------------ AVIONCL DOWN ------------------------------------------------------
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

            rg.useGravity = true;
            rg.AddForce(scriptMovement.thrust * scriptMovement.speed * scriptMovement.speed / kamGaOdfuka);

            Explode();
            audioManager.playExplosion();
            permission = false;
        }
    }

        

        private void Explode()
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Debug.Log("AvionclExplodiru");
        }
    }