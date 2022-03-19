﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Collider2D.FindObjectOfType<Asteroid>())
        {
            collider.GetComponent<Asteroid>().CallWarning();
        }
    }
}