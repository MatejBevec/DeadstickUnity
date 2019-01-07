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
    
    


    void OnCollisionEnter(UnityEngine.Collision collision)
    {
            if (permission)
            {
            followAvioncl.enabled = false;
            aViewFromHeaven.enabled = true;
            scriptMovement.enabled = false;
            torpedoMovement.enabled = false;
            //AVIONCL.EXPLODE!!!!!!
            rg.useGravity = true;
            audioManager.playExplosion();
            rg.AddForce(scriptMovement.thrust * scriptMovement.speeed * scriptMovement.speeed / kamGaOdfuka);
            permission = false;
            }
    }
}
