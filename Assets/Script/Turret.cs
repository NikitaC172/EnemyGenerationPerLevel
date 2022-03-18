using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Turret : MonoBehaviour
{
    private Transform _transform = null;
    private ParticleSystem _particleSystemShoot = null;
    private AudioSource _audioSourceShoot = null;

    private bool _isReadyShoot = true;
    private float _timeBetweenShoot = 1.8f;

    private void OnEnable()
    {
        _transform = GetComponent<Transform>();
        _particleSystemShoot = GetComponent<ParticleSystem>();
        _audioSourceShoot = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        _transform.eulerAngles = new Vector3(0f, 0f, -math.degrees(math.atan2(mousePosition.x, mousePosition.y)));

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
            _particleSystemShoot.Play();
            _audioSourceShoot.Play();
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
