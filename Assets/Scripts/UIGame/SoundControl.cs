using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    [SerializeField]
    public AudioSource musicSource;
    [SerializeField]
    public AudioSource sfxSource;

    public AudioClip death;
    public AudioClip bullet;
    public AudioClip attack;
    public AudioClip enemyAttack;

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
