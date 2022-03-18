using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float _minForce = 15.0f;
    [SerializeField] private float _maxForce = 25.0f;
    [SerializeField] private float _minScale = 0.5f;
    [SerializeField] private float _maxScale = 1.0f;
    [SerializeField] private string _namePointDestination = "Station";
    [SerializeField] private GameObject _objectWithSpriteRender = null;
    [SerializeField] private GameObject _objectWithTrigon = null;

    private GameObject _destination = null;
    private Text _textCount = null;
    private Rigidbody2D _rigidbody2D = null;
    private string _showAsteroidAnimation = "ShowAsteroid";
    private string _showTrigonAnimation = "ShowTrigon";
    private bool _isActive = true;
    private float _timeDestroy = 0.5f;


    public void Remove()
    {
        Destroy(gameObject);
    }

    public void Destroy()
    {
        if (_isActive)
        {
            _isActive = false;
            GetComponent<ParticleSystem>().Play();
            GetComponent<AudioSource>().Play();
            _textCount.GetComponent<Count>().Increase();
            Destroy(gameObject, _timeDestroy);
        }
    }

    public void Detect()
    {
        _objectWithSpriteRender.GetComponent<Animator>().Play(_showAsteroidAnimation);
        _objectWithSpriteRender.GetComponent<AudioSource>().Play();
    }

    public void ShowTrigon()
    {
        _objectWithTrigon.GetComponent<Animator>().Play(_showTrigonAnimation);
        _objectWithTrigon.GetComponent<AudioSource>().Play();
    }

    private void OnEnable()
    {
        _textCount = GameObject.FindObjectOfType<Text>();
        _destination = GameObject.Find(_namePointDestination);
        float scale = UnityEngine.Random.Range(_minScale, _maxScale);
        GetComponent<Transform>().localScale = new Vector3(scale, scale, scale);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce((_destination.transform.position - transform.position) * Random.Range(_minForce, _maxForce));
    }
}
