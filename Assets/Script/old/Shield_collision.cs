using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_collision : MonoBehaviour
{
    private ParticleSystem _particleSystem = null;

    private void Start()
    {     
        _particleSystem = GetComponent<ParticleSystem>();        
    }

    private void OnCollisionEnter2D(Collision2D collision)    
    {
        if (collision.gameObject.TryGetComponent<Asteroid>(out Asteroid asteroid))
        {
            _particleSystem.Play();
            asteroid.Destroy();
            GetComponent<AudioSource>().Play();
        }
    }
}
