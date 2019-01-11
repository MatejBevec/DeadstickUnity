using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    // Start is called before the first frame update
    public avionclMovement avionclMovement;
    public TorpedoMovement torpedoMovement1;
    public TorpedoMovement torpedoMovement2;

    public avionclMovement drugiAvionclMovement;
    public TorpedoMovement drugiTorpedoMovement1;
    public TorpedoMovement drugiTorpedoMovement2;

    public void enableInput()
    {
        avionclMovement.inputEnabled = true;
        torpedoMovement1.inputEnabled = true;
        torpedoMovement2.inputEnabled = true;

        drugiAvionclMovement.inputEnabled = true;
        drugiTorpedoMovement1.inputEnabled = true;
        drugiTorpedoMovement2.inputEnabled = true;
    }

    public void disableInput()
    {
        avionclMovement.inputEnabled = false;
        torpedoMovement1.inputEnabled = false;
        torpedoMovement2.inputEnabled = false;

        drugiAvionclMovement.inputEnabled = false;
        drugiTorpedoMovement1.inputEnabled = false;
        drugiTorpedoMovement2.inputEnabled = false;
    }
}