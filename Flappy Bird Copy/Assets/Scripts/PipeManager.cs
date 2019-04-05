using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    // This is the template we're spawning from.
    public Pipe pipePrefab;

    // The minimum height to spawn the pipe.
    public float minY = 0f;

    // The maximum height to spawn the pipe.
    public float maxY = 10f;

    // Pipes will be spawned with a delay in between.
    public float spawnInterval = 1f;

    // This method will start the pipe spawning routine.
    public void Spawn()
    {
        StartCoroutine(SpawnPipes());
    }

    // Will disable the colliders on all the pipes in the scene.
    public void Disable()
    {
        Pipe[] pipes = FindObjectsOfType<Pipe>();
        foreach (Pipe p in pipes) p.Disable();
    }

    private IEnumerator SpawnPipes()
    {
        // Only spawn pipes when the game is playing.
        while (GameManager.state == GameState.Game)
        {
            // Create a variable containing the spawn point position.
            Vector3 pos = transform.position;

            // Move the point to fit the range we've established.
            pos.y = Random.Range(minY, maxY);

            // Create a copy of the pipe.
            Instantiate<Pipe>(pipePrefab, pos, Quaternion.identity);

            // Delay the function by an amount of time,
            // so we don't break the game.
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
