using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;                   //캐릭터 이동속도를 조절   
    public float jumpForce = 5f;                   //캐릭터 점프힘 조절
    public Transform groundcheck;                  //캐릭터가 땅에 닿았는지 확인
    public LayerMask groundlayer;                  //땅의 레이러를 나타냄    
    public float fallSpeed = 0f;
    public int itemget = 0;

    private Rigidbody2D rb;
    private Animator pAni;
    private bool isGrounded;
    private bool Cold;

    float score;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pAni = GetComponent<Animator>();

        score = 10000f;
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            pAni.SetBool("RunAction",true);
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            pAni.SetBool("RunAction",true);
        }
        else
        {
            pAni.SetBool("RunAction", false);
        }
        
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                pAni.SetTrigger("JumpAction");
            }
            else if (itemget > 0)
            {
                itemget -= 1;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                pAni.SetTrigger("JumpAction");
            }
        }

        score -= Time.deltaTime*10; 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            if (Cold)
            {
                
            }
            else
            {
                SceneManager.LoadScene("DeadScene");
            }
        }
        if (collision.CompareTag("Item"))
        {
            itemget++;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("ColdItem"))
        {
            Destroy(collision.gameObject);
            Cold = true;
            Invoke("Wait5sec", 5f);
        }
        if (collision.CompareTag("SpeedItem"))
        {
            Destroy(collision.gameObject);
            moveSpeed = 5f;
        }
        if (collision.CompareTag("JumpItem"))
        {
            Destroy(collision.gameObject);
            jumpForce = 7f;
        }
            if (collision.CompareTag("Finish"))
        {
            HighScore.TrySet(SceneManager.GetActiveScene().buildIndex, (int)score);
            collision.GetComponent<LevelObject>().MovetoNextLevel();
        }
        if (collision.CompareTag("Death"))
        {
            jumpForce = 9f;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpForce = 5f;
            pAni.SetTrigger("JumpAction");
        }
        if (collision.CompareTag("Jump"))
        {
            jumpForce = 10f;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpForce = 5f;
            pAni.SetTrigger("JumpAction");
        }
    }
    void Wait5sec()
    {
        Cold = false;
    }
}