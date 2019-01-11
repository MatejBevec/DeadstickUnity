using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class rotatePropeler : MonoBehaviour
{
    public AudioSource planeAudio;
    public avionclMovement scriptMovement;

    public float propelerRotation;
    public float audioPropelerPitchDivider;
    public float audioPropelerVolumeDivider;
    public float maxPitch;

    private float pitchLevel;
    private float maxPropelerRotation;

    private bool AlreadyGotMaxSpeed = false;


    private void getMaxSpeed()
    {
            maxPropelerRotation = scriptMovement.speed * maxPitch;
            audioPropelerVolumeDivider = scriptMovement.maxSpeed / 2;
    }
   
    void Update()
    {
        //------------------------------------------ GET MAX SPEED WHEN NEEDED ------------------------------------------------------
        if (!AlreadyGotMaxSpeed) {
            getMaxSpeed();
            AlreadyGotMaxSpeed = true;
        }

        //------------------------------------------ DO NOT OVERROTATE PROPELER ------------------------------------------------------
        if (propelerRotation > maxPropelerRotation)
            {
                propelerRotation = maxPropelerRotation;
            }

        //------------------------------------------ CALCULATE ROTATION AND ROTATE IT ------------------------------------------------------
        propelerRotation = scriptMovement.speed * scriptMovement.thrustLevel;
        transform.Rotate(0f,0f,propelerRotation);

        ////------------------------------------------ HANDLE AUDIO (BASED ON PROPELER) ------------------------------------------------------
        pitchLevel = propelerRotation / audioPropelerPitchDivider;
        planeAudio.pitch = pitchLevel;
        planeAudio.volume = (audioPropelerVolumeDivider) / scriptMovement.speed;

     

    }
}
