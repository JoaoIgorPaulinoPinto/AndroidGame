using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFXControler : MonoBehaviour
{
    [SerializeField] AudioSource btnAudioSource;
    [SerializeField] AudioClip btnSound;
    
    public void PlayAudio()
    {
        btnAudioSource.clip = btnSound;
        btnAudioSource.loop = false;
        btnAudioSource.Play();
    }
}
