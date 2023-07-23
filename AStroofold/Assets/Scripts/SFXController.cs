using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SFXController : MonoBehaviour
{
    public AudioClip startSound;
    public AudioClip engineSound;
    public AudioClip lasershoot;
    public WeaponSystem weaponSystem;

    private AudioSource audioSource;

    void Start()
    {
        weaponSystem = GetComponent<WeaponSystem>();
        audioSource = GetComponent<AudioSource>();

        // Reproduz o som de ligar o motor
        if (startSound != null)
        {
            audioSource.clip = startSound;
            audioSource.Play();
        }
    }

    void Update()
    {
        // Verifica se o som de ligar o motor terminou e reproduz o som em loop do motor
        if (!audioSource.isPlaying && engineSound != null)
        {
            audioSource.clip = engineSound;
            audioSource.loop = true;
            audioSource.Play();
        }

        if (weaponSystem.shootReady == true)
        {
            audioSource.clip = lasershoot;
            audioSource.Play();
        }
        
    }
}
