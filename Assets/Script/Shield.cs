using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ParticleSystem))]

public class Shield : MonoBehaviour
{
    private ParticleSystem _particleSystem = null;
    private AudioSource _shieldSound = null;

    private void Start()
    {     
        _particleSystem = GetComponent<ParticleSystem>();
        _shieldSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Asteroid>(out Asteroid asteroid))
        {
            _particleSystem.Play();
            asteroid.Destroy();
            _shieldSound.Play();
        }
    }
}
