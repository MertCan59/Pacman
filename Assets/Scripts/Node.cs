using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask obstacleLayer;
    public List<Vector2> availableDirections {  get; private set; }
    private void Start()
    {
        availableDirections = new List<Vector2> ();
        ChechkAvailableDirection(Vector2.up);
        ChechkAvailableDirection(Vector2.down);
        ChechkAvailableDirection(Vector2.left);
        ChechkAvailableDirection(Vector2.right);
    }
    void ChechkAvailableDirection(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.0f, this.obstacleLayer);
        if(hit.collider == null)
        {
            this.availableDirections.Add (direction);
        }
    }
}
