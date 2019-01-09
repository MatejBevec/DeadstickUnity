using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replay : MonoBehaviour
{
	

    void Start()
    {
 
    }

    void FixedUpdate()
    {
    		if (record.isFinal == true) { //če imamo kopijo za ghosta
        transform.position = record.positionsFinal[record.a]; //premika se po pozicijah kopije
        transform.rotation = record.rotationsFinal[record.a]; //rotira po rotacijah kopije
        
    	}
    }
}



