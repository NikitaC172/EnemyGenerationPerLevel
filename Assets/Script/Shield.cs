using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private ParticleSystem _particleSystem = null;

    private void Start()
    {     
        _particleSystem = GetComponent<ParticleSystem>();        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Collider2D.FindObjectOfType<Asteroid>())
        {
            _particleSystem.Play();
            collider.GetComponent<Asteroid>().Destroy();
            GetComponent<AudioSource>().Play();
        }
    }
}
