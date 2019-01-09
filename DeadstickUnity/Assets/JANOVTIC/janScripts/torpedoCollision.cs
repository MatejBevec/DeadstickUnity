using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class torpedoCollision : MonoBehaviour
{
    public GameObject explosionEffect;

    public AudioManager AudioManager;
    public GameObject torpedo;
    public float secToDestroy;
    private bool exlosionPlayed1 = false;
    public bool izstreljen = false;
  
    private void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (!exlosionPlayed1&&izstreljen&&collision.collider.tag == "Ovira")
        {
            Destroy(gameObject, secToDestroy);
            AudioManager.playExplosion();
            exlosionPlayed1 = true;
            Explode();
            Debug.Log("Torpedo Explodiru");
        }
    }

   
}

