using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    private bool isMovingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (isMovingRight)
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            transform.localScale = new Vector3(-9.365812f, 9.365812f, 9.365812f);
            isMovingRight = !isMovingRight;
        }
        {
            if (collision.CompareTag("Boundary2"))
            {
                transform.localScale = new Vector3(9.365812f, 9.365812f, 9.365812f);
                isMovingRight = !isMovingRight;
            }
            if (collision.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
    }
}
