using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundeffects : MonoBehaviour
{
    [SerializeField] public AudioSource player;
 
    public void PlayAudio(AudioClip music)
    {
        player.clip = music;
        player.Play();
    }
}
