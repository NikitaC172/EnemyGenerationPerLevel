using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(AudioSource))]

public class Turret : MonoBehaviour
{
    private ParticleSystem _shoot = null;
    private AudioSource _shootSound = null;

    private bool _isReadyShoot = true;
    private float _timeBetweenShoot = 1.8f;

    private void Awake()
    {
        _shoot = GetComponent<ParticleSystem>();
        _shootSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.eulerAngles = new Vector3(0f, 0f, -math.degrees(math.atan2(mousePosition.x, mousePosition.y)));

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void OnParticleCollision(GameObject gameObject)
    {
        if (gameObject.TryGetComponent<Asteroid>(out Asteroid asteroid))
        {
            asteroid.Destroy();
        }
    }

    private void Shoot()
    {
        if (_isReadyShoot)
        {
            _isReadyShoot = false;
            _shoot.Play();
            _shootSound.Play();
            StartCoroutine(WaitBetweenShots(_timeBetweenShoot));
        }
    }

    private IEnumerator WaitBetweenShots(float timeBetweenShoot)
    {
        var waitSeconds = new WaitForSeconds(timeBetweenShoot);
        yield return waitSeconds;
        _isReadyShoot = true;
    }
}
