using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 3f;
    public float jumpInterval = 2f;
    private Rigidbody2D rb;
    private bool isMovingRight = true;
    private Animator pAni;

    public GameObject Goal;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent<Animator>();
        InvokeRepeating("Jump", jumpInterval, jumpInterval);
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
            transform.localScale = new Vector3(2.074753f, 2.074753f, 2.074753f);
            isMovingRight = !isMovingRight;
            pAni.SetBool("isMoving", true);
        }
         else if (collision.CompareTag("Boundary2"))
            {
                transform.localScale = new Vector3(-2.074753f, 2.074753f, 2.074753f);
                isMovingRight = !isMovingRight;
                pAni.SetBool("isMoving", true);
            }
        else
        {
            pAni.SetBool("isMoving", false);
        }
        if (collision.CompareTag("Player") && Goal !=null)
            {
                Destroy(gameObject);
            Goal.SetActive(true);
            }
    }
    void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            pAni.SetTrigger("Jump");
        }
    }
    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
        return hit.collider != null;
    }
}
