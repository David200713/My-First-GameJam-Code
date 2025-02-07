using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    [Header("---------Audio Source---------")]
    [SerializeField]AudioSource soundSrc;
    [SerializeField]AudioSource musicSource;

    [Header("---------Audio Clip---------")]
    public AudioClip jump, attack, explosion, btnClick, slider, background, bossDeath, hit, playerDeath;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        soundSrc.PlayOneShot(clip);
    }
}
