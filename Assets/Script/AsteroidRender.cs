using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]

public class AsteroidRender : MonoBehaviour
{
    private AudioSource _detectSound = null;
    private Animator _showSprite = null;
    private const string _showTrigonAnimation = "ShowAsteroid";

    public void Detect()
    {
        _detectSound.Play();
        _showSprite.Play(_showTrigonAnimation);
    }

    private void Awake()
    {
        _detectSound= GetComponent<AudioSource>();
        _showSprite = GetComponent<Animator>();
    }
}
