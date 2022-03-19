using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPointParent = null;
    [SerializeField] private Asteroid _asteroid = null;
    [SerializeField] private float _timeBetweenSpawn = 2f;
    [SerializeField] private GameObject _directionMove = null;
    [SerializeField] private Count _textCount = null;

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
            Asteroid asteroid = Instantiate(_asteroid,_points[random.Next(firstElement, _points.Length)]);
            asteroid.SetDirectionAndCounter(_textCount, _directionMove);
            yield return waitSeconds;
        }
    }
}
