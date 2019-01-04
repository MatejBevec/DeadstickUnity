using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avionclMovement : MonoBehaviour
{

    public float minSpeed; //pr tej hitrosti bo avion začel padati
    public float maxSpeed; //max hitrost brez posbeška teže
    public static float speed; //hitrost avioncla
    public float speeed; // za spremljanje hitrosti avioncla
    public float startSpeed; //hitrost ob začetku igre

    public float turnSpeed;//večji se hitreje obrača
    public float verticalLessThanHorizontal;//uporabljen pri turn speedu da se avion hitreje vrti horizontalno kot vertikalno

    public float wingArea;  // večji ko je bolj avion zavije v ovinek
    public float turnLift; //reccomended 1.4   -   večji ko je manj lifta imamo v ovinku
    public float enginePower; //večji hitreje pospešuje
    public float dragPower; //večji hitreje se ustavi ko ne držimo pogona
    public float weight;  //večji hitreje pada, težje se dvigne

    public float gravity; //=pospešekmanjsi ko je vecji je

    private Vector3 thrust;
    private Vector3 vecDown;

    void Start()
    {
        vecDown = -(Vector3.up);
        speed = startSpeed;
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
            transform.position += vecDown * ((minSpeed - speed) / (gravity * 2 * weight));

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
                 transform.Rotate(-wingArea * transform.right.y, -wingArea * turnLift * transform.right.y, 0f);
            }
            if (transform.right.y < 0f)
            {
                transform.Rotate(wingArea * transform.right.y, -wingArea * turnLift * transform.right.y, 0f);
               // transform.Rotate(0f, -0.4f * transform.right.y, 0f, Space.World);
            }
      




    }
}
