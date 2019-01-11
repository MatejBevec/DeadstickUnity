using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TorpedoMovement : MonoBehaviour
{
    public AudioManager AudioManager;

    public Rigidbody rg;

    public Transform avioncl;
    public avionclMovement scriptMovement;

    public Transform drugiAvioncl;
    public avionclMovement drugiAvionclScript;

    public torpedoCollision torpedoCollision;
    Collider torpedoCollider;

    public float shootingPower;

    public float kotPriKateremSeZasleduje;

    public string shootInput;

    public float kolikoNaprej;

    public bool inputEnabled = false;

    private bool shoot = false;
    private Vector3 torpedoPower;
    private bool streljajNaravnost = true;



    void Start()
    {
        torpedoCollider = GetComponent<Collider>();
        torpedoCollider.isTrigger = true;
        Physics.IgnoreCollision(avioncl.GetComponent<Collider>(), GetComponent<Collider>());
    }

  

    void Update()
    {
        if (!scriptMovement.pauseGame && inputEnabled) {

            if (shoot || Input.GetKeyDown(shootInput))
            {

                if (!shoot)
                {
                    AudioManager.playLaunch();
                    transform.parent = null;
                    shoot = true;
                    Destroy(gameObject, torpedoCollision.secToDestroy);
                    torpedoCollision.izstreljen = true;
                    torpedoCollider.isTrigger = false;

                    //------------------------------------------ CHECK IF TORPEDO WILL FOLLOW ------------------------------------------------------
                    Vector3 a = new Vector3(drugiAvioncl.position.x - avioncl.position.x, drugiAvioncl.position.y - avioncl.position.y, drugiAvioncl.position.z - avioncl.position.z);
                    if (Vector3.Angle(transform.forward,a) <= kotPriKateremSeZasleduje)
                    {
                        streljajNaravnost = false;
                    }
                }

                if (streljajNaravnost)
                {
                    fireStraight();
                }
                else
                {
                    fire();
                }

            }
        }
    }

    void fire()
    {
        kolikoNaprej = Vector3.Distance(this.transform.position,drugiAvioncl.transform.position)/(rg.mass * shootingPower/2) * (drugiAvionclScript.speed);
        torpedoPower = transform.forward * shootingPower * scriptMovement.speed / (scriptMovement.maxSpeed / 2);
        this.transform.LookAt(drugiAvioncl.transform.position + (drugiAvioncl.transform.forward * kolikoNaprej));
        rg.AddForce(torpedoPower);
    }

    void fireStraight()
    {
        torpedoPower = transform.forward * shootingPower * scriptMovement.speed / (scriptMovement.maxSpeed / 2);
        rg.AddForce(torpedoPower);
    }


}
