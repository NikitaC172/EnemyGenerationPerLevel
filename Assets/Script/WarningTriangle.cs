using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]

public class WarningTriangle : MonoBehaviour
{
    private AudioSource _warningSound = null;
    private Animator _warningAnimator = null;
    private const string ShowTrigonAnimation = "ShowTrigon";

    public void Warn()
    {
        _warningSound.Play();
        _warningAnimator.Play(ShowTrigonAnimation);
    }

    private void Awake()
    {
        _warningSound = GetComponent<AudioSource>();
        _warningAnimator = GetComponent<Animator>();
    }
}
