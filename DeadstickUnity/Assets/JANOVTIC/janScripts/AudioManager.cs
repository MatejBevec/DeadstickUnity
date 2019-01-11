using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioLaunch;
    public AudioSource audioExplosion;
    
    public void playExplosion()
    {
        audioExplosion.Play();
    }

    public void playLaunch()
    {
        audioLaunch.Play();
    }
}
