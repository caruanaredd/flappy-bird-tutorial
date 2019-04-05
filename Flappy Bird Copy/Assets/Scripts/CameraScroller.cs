using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    [Tooltip("The speed by which the scene will move.")]
    public float speed = 15f;

    // Move the camera consistently to the right.
    private void Update()
    {
        if (GameManager.state == GameState.GameOverScreen) return;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
