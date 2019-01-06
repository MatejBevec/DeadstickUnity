using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public followAvioncl followAvioncl;
    public aViewFromHeaven aViewFromHeaven;
    public avionclMovement scriptMovement;
    public Rigidbody rg;
    public float kamGaOdfuka;
    private bool permission = true;
    


    void OnCollisionEnter(UnityEngine.Collision collision)
    {
       
            followAvioncl.enabled = false;
            aViewFromHeaven.enabled = true;
            scriptMovement.enabled = false;
            //AVIONCL.EXPLODE!!!!!!
            rg.useGravity = true;
            if (permission)
            {
                rg.AddForce(scriptMovement.thrust * scriptMovement.speeed * scriptMovement.speeed / kamGaOdfuka);
                permission = false;
            }
        

            
            
    }

}
