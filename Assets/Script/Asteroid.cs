using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ParticleSystem))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody2D))]

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _minForce = 15.0f;
    [SerializeField] private float _maxForce = 25.0f;
    [SerializeField] private float _minScale = 0.5f;
    [SerializeField] private float _maxScale = 1.0f;
    [SerializeField] private AsteroidRender _objectWithSpriteRender = null;
    [SerializeField] private WarningTriangle _objectWithTrigon = null;

    private ParticleSystem _destructionParticles = null;
    private AudioSource _destructionSound = null;
    private GameObject _directionMove = null;
    private AsteroidsDestroyedCounter _textCount = null;
    private Rigidbody2D _rigidbody2D = null;
    private bool _isActive = true;
    private float _timeDestroy = 0.5f;

    public void SetDirectionAndCounter(AsteroidsDestroyedCounter count, GameObject directionMove)
    {
        _directionMove = directionMove;
        _textCount = count;
    }

    public void Remove()
    {
        Destroy(gameObject);
    }

    public void Destroy()
    {
        if (_isActive)
        {
            _isActive = false;
            _destructionParticles.Play();
            _destructionSound.Play();
            _textCount.Increase();
            Destroy(gameObject, _timeDestroy);
        }
    }

    public void Detect()
    {
        _objectWithSpriteRender.Detect();
    }

    public void CallWarning()
    {
        _objectWithTrigon.Warn();
    }

    private void Awake()
    {
        float scale = UnityEngine.Random.Range(_minScale, _maxScale);
        _destructionParticles = GetComponent<ParticleSystem>();
        _destructionSound = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(scale, scale, scale);        
    }

    private void Start()
    {
        _rigidbody2D.AddForce((_directionMove.transform.position - transform.position) * Random.Range(_minForce, _maxForce));
    }
}
