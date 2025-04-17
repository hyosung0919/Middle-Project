using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraceController : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float raycastDistance = 0.2f;
    public float traceDistance = 2f;

    private Transform player;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector2 direction = player.position - transform.position;

        if (direction.magnitude > traceDistance)
            return;

        Vector2 directionNormalized = direction.normalized;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, directionNormalized, raycastDistance);
        Debug.DrawRay(transform.position, directionNormalized * raycastDistance, Color.red);

        bool hitGround = false;
        foreach (RaycastHit2D rHit in hits)
        {
            if (rHit.collider != null && rHit.collider.CompareTag("Ground"))
            {
                hitGround = true;
                break;
            }
        }

        if (hitGround)
        {
            Vector3 alternativeDirection = Quaternion.Euler(0f, 0f, -90f) * directionNormalized;
            transform.Translate(alternativeDirection * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(directionNormalized * moveSpeed * Time.deltaTime);
        }
    }
}
