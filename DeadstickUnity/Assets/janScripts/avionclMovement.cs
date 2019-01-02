using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avionclMovement : MonoBehaviour
{
    public float turnSpeed;
    private Vector3 thrust;
    public float minSpeed;
    public float maxSpeed;
    public static float speed;
    public float speeed;
    public float enginePower;
    public float dragPower;
    public float weight;
    private Vector3 vecDown;
    public float verticalLessThanHorizontal;
    public float gravity; //manjsi ko je vecji je
    public float startSpeed;

    
    void Start()
    {
        vecDown = -(Vector3.up);
        speed = startSpeed;
    }

    public float getSpeed()
    {
        return maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        speeed = speed;

        //TURN
        transform.Rotate(turnSpeed / verticalLessThanHorizontal * Input.GetAxis("Vertical"), 0, -turnSpeed * Input.GetAxis("Horizontal"));

        //CALCULATE THRUST
        thrust = transform.forward * speed * Time.deltaTime;

        //MOVE AVIONCL
        transform.position += thrust;

        //THRUST
        if (Input.GetKey("space") && speed < maxSpeed)
        {
            speed *= enginePower;
        }
        else if (speed > minSpeed)
        {
            speed /= dragPower;
        }


        //PREMALO SPEEDA
        if (speed < minSpeed)
        {
            transform.position += vecDown * ((minSpeed - speed) / (40 * weight));

            if (transform.up.y > 0f)
            {
                transform.Rotate((minSpeed - speed) * (weight*2), 0f, 0f);
            }
            else
            {
                transform.Rotate(-(minSpeed - speed) * (weight*2), 0f, 0f);
            }
        }


        //OBNAŠANJE AVIONCLA ZARADI TEŽE
        if (transform.forward.y > 0f)
        {
            speed /= 1f + (transform.forward.y * weight / gravity);
        }
        if (transform.forward.y < 0f)
        {
            speed *= 1f + -(transform.forward.y) * weight / gravity;
        }



        //OBAŠANJE AVIONCLA ZARADI VZGONA
        //TAZAKOMENTIRANI SO VRTENJE OKOLI GLOBALNEGA Y TUD KR UREDU ZA FURAT
            if (transform.right.y > 0f)
            {
               //transform.Rotate(0f, -0.4f * transform.right.y, 0f, Space.World);
                 transform.Rotate(-weight * transform.right.y, -weight * 1.4f * transform.right.y, 0f);
            }
            if (transform.right.y < 0f)
            {
                transform.Rotate(weight * transform.right.y, -weight * 1.4f * transform.right.y, 0f);
               // transform.Rotate(0f, -0.4f * transform.right.y, 0f, Space.World);
            }
      




    }
}
