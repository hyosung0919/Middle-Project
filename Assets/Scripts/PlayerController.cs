using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;                   //캐릭터 이동속도를 조절   
    public float jumpForce = 5f;                   //캐릭터 점프힘 조절
    public Transform groundcheck;                  //캐릭터가 땅에 닿았는지 확인
    public LayerMask groundlayer;                  //땅의 레이러를 나타냄    

    public int itemget = 0;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else if(itemget >0)
            {
                itemget -= 1;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Respawn"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        }
        if (collision.CompareTag("Item"))
        {
            itemget++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Finish"))
        {
            collision.GetComponent<LevelObject>().MovetoNextLevel();
        }
        if (collision.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
