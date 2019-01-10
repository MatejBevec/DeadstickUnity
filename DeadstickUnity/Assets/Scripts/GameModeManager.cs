using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class GameModeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    abstract public void RunCompleted(float runDuration, List<float> timeList);


}
