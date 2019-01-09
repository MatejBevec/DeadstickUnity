using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avionclMovement : MonoBehaviour
{

    public float minSpeed; //pr tej hitrosti bo avion začel padati
    public float maxSpeed; //max hitrost brez posbeška teže
    public float speed; // za spremljanje hitrosti avioncla
    public float startSpeed; //hitrost ob začetku igre
    public float thrustLevel;
    public float thrustLevelOn; //samo za propeler
    public float thrustLevelOff; //samo za propeler

    public float turnSpeed;//večji se hitreje obrača
    public float pullPower;//uporabljen pri turn speedu da se avion hitreje vrti horizontalno kot vertikalno

    public float wingArea;  // večji ko je bolj avion zavije v ovinek
    public float turnLift; //reccomended 1.4   -   večji ko je manj lifta imamo v ovinku
    public float enginePower; //večji hitreje pospešuje
    public float dragPower; //večji hitreje se ustavi ko ne držimo pogona
    public float weight;  //večji hitreje pada, težje se dvigne
    public float pocasnejeDol;

    public float gravity; //= težni pospešek   (manjsi ko je vecji je)

    public Vector3 thrust;
    private Vector3 vecDown;

    private bool pauseGame = false;

    public string inputVerical;
    public string inputHorizontal;
    public string inputAccelaration;






    void Start()
    {
        vecDown = -(Vector3.up);
        speed = startSpeed;
        Time.timeScale = 1f;
        thrustLevel = thrustLevelOff;
    }

   




    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseGame)
            {
                pauseGame = false;
            }
            else
            {
                pauseGame = true;
                thrustLevel = 0;
            }

        }




        if (!pauseGame) //če ni pauze se use skp začne
        {


            //------------------------------------------ TURN ------------------------------------------------------
            transform.Rotate(turnSpeed / pullPower * Input.GetAxis(inputVerical), 0, -turnSpeed * Input.GetAxis(inputHorizontal));

            //------------------------------------------ CALCULATE THRUST ------------------------------------------------------
            thrust = transform.forward * speed * Time.deltaTime;

            //------------------------------------------ MOVE AVIONCL ------------------------------------------------------
            transform.position += thrust;

            //------------------------------------------ THRUST ------------------------------------------------------
            if (Input.GetKey(inputAccelaration) && speed < maxSpeed)
            {
                speed *= enginePower;


            }
            else if (speed > minSpeed)
            {
                speed /= dragPower;


            }

            if (Input.GetKeyDown(inputAccelaration))
            {
                thrustLevel = thrustLevelOn;
            }
            if (Input.GetKeyUp(inputAccelaration))
            {
                thrustLevel = thrustLevelOff;
            }


            // ------------------------------------------ PREMALO SPEEDA ------------------------------------------------------
            if (speed < minSpeed)
            {
                transform.position += vecDown * (1 - wingArea) * ((minSpeed - speed) / (gravity * 2 * weight));

                if (transform.up.y > 0f)
                {
                    transform.Rotate((minSpeed - speed) * (weight * (1 - wingArea) * 5), 0f, 0f);
                }
                else
                {
                    transform.Rotate(-(minSpeed - speed) * (weight * (1 - wingArea) * 5), 0f, 0f);
                }
            }


            //------------------------------------------ OBNAŠANJE AVIONCLA ZARADI TEŽE ------------------------------------------------------
            if (transform.forward.y > 0f)
            {
                speed /= 1f + (transform.forward.y * weight / gravity);
            }
            if (transform.forward.y < 0f)
            {
                speed *= 1f - ((transform.forward.y * weight / gravity)/pocasnejeDol);
            }



            //------------------------------------------ OBAŠANJE AVIONCLA ZARADI VZGONA ------------------------------------------------------

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
}
