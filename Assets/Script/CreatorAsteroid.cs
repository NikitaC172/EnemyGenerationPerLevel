using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CreatorAsteroid : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPointParent = null;
    [SerializeField] private GameObject _asteroid = null;
    [SerializeField] private float _timeBetweenSpawn = 2f;

    private Transform[] _points;

    private void OnEnable()
    {
        _points = _spawnPointParent.GetComponentsInChildren<Transform>();
        StartCoroutine(Create(_timeBetweenSpawn));
    }


    private IEnumerator Create(float timeBetweenSpawn)
    {
        int firstElement = 1;
        System.Random random = new System.Random();
        var waitSeconds = new WaitForSeconds(timeBetweenSpawn);
        while (true)
        {
            GameObject gameObject = Instantiate(_asteroid, _points[random.Next(firstElement, _points.Length)]);
            yield return waitSeconds;
        }
    }
}
