using UnityEngine;
using System.Collections;

public class GhostHome : GhostBehaviour
{
    public Transform inside;
    public Transform outside;


    private void OnEnable()
    {
        StopAllCoroutines();
    }
    private void OnDisable()
    {
        if(gameObject.activeSelf)
        {
            StartCoroutine(ExitTransition());
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            ghost.movement.SetDirection(-ghost.movement.direction);
        }
    }
    private IEnumerator ExitTransition()
    {
        ghost.movement.SetDirection(Vector2.up,true);
        ghost.movement.rgb.isKinematic = true;
        ghost.movement.enabled = false;

        Vector3 position = transform.position;
        float duration = 0.5f;
        float elapsed = 0.0f;
        while(elapsed<duration)
        {
            Vector3 newPosition = Vector3.Lerp(position, inside.position, elapsed/duration);
            newPosition.z=position.z;
            ghost.transform.position = position;
            elapsed += Time.deltaTime;
            yield return null;
        }
        elapsed = 0.0f;

        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(inside.position, outside.position, elapsed / duration);
            newPosition.z = position.z;
            ghost.transform.position = position;
            elapsed += Time.deltaTime;
            yield return null;
        }


        ghost.movement.SetDirection(new Vector2(Random.value<0.5f? -1.0f:1.0f,0.0f), true);
        ghost.movement.rgb.isKinematic = false;
        ghost.movement.enabled = true;


    }
}
