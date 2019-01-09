using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class record : MonoBehaviour
{	

    public static List <Vector3> positions;
    public static List <Vector3> positionsFinal;
    public static List <Quaternion> rotations;
    public static List <Quaternion> rotationsFinal;
    public static bool isFinal;
    public static bool restart;
	public static int a;

    void Start()
    {
            positions = new List <Vector3>(); //list pozicij
            rotations = new List <Quaternion>(); //list rotacij
            a = 0; //indeks v listu
            isFinal = false; //nimamo še lista za premikanje ghosta
           }
  

    void FixedUpdate()
    {
            
            positions.Insert(a, transform.position); //filanje list pozicij
            rotations.Insert(a, transform.rotation); //filanje list rotacij
            a++;


            if (transform.position.z > -300){ //"namišljen" konec proge
            End();
        }
    }

        void End() {
                
                Write(); //kopira pozicije trenutnega poskusa v nov list, po katerem se premika ghost - tukaj se določi pogoj za prepis, torej, če je dosežen najboljši čas do sedaj

                if (isFinal==true) {

                positions.Clear(); //pobriše originalen list
                
                transform.position = new Vector3(0, 121, -657); //vrne na začetek - samo za test "restarta"
                transform.rotation = new Quaternion(0, 0, 0, 0); //vrne na začetek - samo za test "restara"
                avionclMovement.speed = 15; //resetira hitrost avioncla za "restart"
                
                a = 0; //resetira index lista
                }
                
                isFinal = true; //imamo kopijo za premikanje ghosta
                }

        void Write() { //kopira original list v list po katerem se premika ghost

                positionsFinal = new List<Vector3>(); 
                positionsFinal.AddRange(positions); //prepiše pozicije
                rotationsFinal = new List<Quaternion>();
                rotationsFinal.AddRange(rotations); //prepiše rotacije
                isFinal = true; //imamo kopijo za premikanje ghosta

            }
    }
    

    
    
    

