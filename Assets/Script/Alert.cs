using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Asteroid>(out Asteroid asteroid))
        {
            asteroid.CallWarning();
        }
    }
}
