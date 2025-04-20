using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float traceDistance = 2f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (player != null) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > traceDistance)
            return;

        Vector2 direction = new Vector2(player.position.x - transform.position.x, 0f).normalized;

        transform.Translate(direction * moveSpeed * Time.deltaTime);

        if ( direction.x != 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.Sign(direction.x) * Mathf.Abs(localScale.x);
            transform.localScale = localScale;
        }
    }
}
