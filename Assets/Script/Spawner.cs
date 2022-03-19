using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnPointParent = null;
    [SerializeField] private Asteroid _asteroid = null;
    [SerializeField] private float _timeBetweenSpawn = 2f;
    [SerializeField] private GameObject _target = null;
    [SerializeField] private AsteroidsDestroyedCounter _textCount = null;

    private Transform[] _points;

    private void OnEnable()
    {
        _points = _spawnPointParent.GetComponentsInChildren<Transform>();
        StartCoroutine(Spawn(_timeBetweenSpawn));
    }

    private IEnumerator Spawn(float timeBetweenSpawn)
    {
        int firstElement = 1;
        var waitSeconds = new WaitForSeconds(timeBetweenSpawn);

        while (true)
        {
            Asteroid asteroid = Instantiate(_asteroid,_points[Random.Range(firstElement, _points.Length)]);
            asteroid.SetDirectionAndCounter(_textCount, _target);
            yield return waitSeconds;
        }
    }
}
