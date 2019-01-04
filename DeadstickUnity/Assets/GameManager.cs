using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool neki = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && neki == false)
        {
            neki = true;
            Time.timeScale = 0f;
        }
            if(Input.GetKeyUp(KeyCode.Escape) && neki == true)
        {
            neki = false;
            Time.timeScale = 1f;
        }
    }
}
