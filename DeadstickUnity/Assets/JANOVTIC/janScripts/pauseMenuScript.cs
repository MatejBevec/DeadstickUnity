using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuScript : MonoBehaviour
{
    public avionclMovement prviAvionc;
    public avionclMovement drugiAvionc;
    public int ExitKolikoScenNazaj; 

    public void resume()
    {
        prviAvionc.resumeGame();
        drugiAvionc.resumeGame();
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - ExitKolikoScenNazaj);
    }
}
