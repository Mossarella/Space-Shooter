using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioSource audiosource;

 
    public AudioClip hover;
    public AudioClip click;
    public AudioClip clickQuit;
    public AudioClip shootSound;
    

    /*public enum soundState
    {
        0=flapSfx,
        1=scoreSfx,
        2=loseSfx,
        3=hoverSfx,
        4=clickSfx,
    }*/
    void Start()
    {
        audiosource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlaySound(int soundState)
    {
        switch (soundState)
        {
           
            case 0:
                audiosource.PlayOneShot(hover);
                break;
            case 1:
                audiosource.PlayOneShot(click);
                break;
            case 3:
                audiosource.PlayOneShot(clickQuit);
                break;
            case 4:
                audiosource.PlayOneShot(shootSound);
                break;
            
            default:
                break;

        }

    }
}
