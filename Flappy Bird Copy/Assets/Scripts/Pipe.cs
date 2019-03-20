using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    // We need to keep track of the colliders
    // in case the player loses.
    private Collider2D[] _colliders;

    private void Awake()
    {
        // This line retrieves the collider of the parent and its children.
        _colliders = GetComponentsInChildren<Collider2D>();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // This function will disable all collisions for this pipe.
    public void Disable()
    {
        foreach (Collider2D c in _colliders) c.enabled = false;
    }
}
