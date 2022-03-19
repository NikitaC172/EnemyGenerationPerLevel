using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]

public class AsteroidRender : MonoBehaviour
{
    private AudioSource _detectSound = null;
    private Animator _showSprite = null;
    private const string ShowTrigonAnimation = "ShowAsteroid";

    public void Detect()
    {
        _detectSound.Play();
        _showSprite.Play(ShowTrigonAnimation);
    }

    private void Awake()
    {
        _detectSound= GetComponent<AudioSource>();
        _showSprite = GetComponent<Animator>();
    }
}
