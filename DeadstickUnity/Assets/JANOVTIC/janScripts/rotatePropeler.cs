using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class rotatePropeler : MonoBehaviour
{
    //public avionclMovement avionclMovementt;
    public AudioSource planeAudio;
    public float propelerRotation;
    public float audioPropelerPitchDivider;
    public float audioPropelerVolumeDivider;
    private float pitchLevel;
    private float maxPropelerRotation;
    public float maxPitch;
    private bool AlreadyGotMaxSpeed = false;
    public avionclMovement scriptMovement;


    private void getMaxSpeed()
    {
            maxPropelerRotation = scriptMovement.speed * maxPitch;
            audioPropelerVolumeDivider = scriptMovement.maxSpeed / 2;
    }
    // Update is called once per frame
    void Update()
    {
        if (!AlreadyGotMaxSpeed) {
            getMaxSpeed();
            AlreadyGotMaxSpeed = true;
        }
        if (propelerRotation > maxPropelerRotation)
            {
                propelerRotation = maxPropelerRotation;
            }

        propelerRotation = scriptMovement.speed * scriptMovement.thrustLevel;


        transform.Rotate(0f,0f,propelerRotation);

        pitchLevel = propelerRotation / audioPropelerPitchDivider;
        planeAudio.pitch = pitchLevel;
        planeAudio.volume = (audioPropelerVolumeDivider) / scriptMovement.speed;

     

    }
}
