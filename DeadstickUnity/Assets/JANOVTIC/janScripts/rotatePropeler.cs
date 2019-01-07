using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class rotatePropeler : MonoBehaviour
{
    public AudioSource propelerAudio;
    private float propelerRotation;
    public float audioPropelerPitchDivider;
    private float pitchLevel = 0.1f;


    // Update is called once per frame
    void Update()
    {
        propelerRotation = avionclMovement.speed * avionclMovement.thrustLevel;
        transform.Rotate(0f,0f,propelerRotation);

        pitchLevel = propelerRotation / audioPropelerPitchDivider;
        if (pitchLevel > 10)
        {
            pitchLevel = 10;
        }

        propelerAudio.pitch = pitchLevel;

        /*ZRIHTAJ DO KONCAS
        if (avionclMovement.thrustLevel>1f)
        {
            pitchLevel *= 1.0001f;
        }
        else
        {
            pitchLevel /= 1.0001f;
        }
        if (pitchLevel>0.2)
        {
            pitchLevel = 1;
        }
        if (pitchLevel == 0f)
        {
            pitchLevel = 0.1f;
        }

        propelerAudio.pitch+= 
        */

    }
}
