using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 5f;
    public float attackCooldown = 2f;
    public int maxHealth = 100;

    private int currentHealth;
    private Transform player;
    private float lastAttackTime;

    private Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            Attack();
        }
    }

    void MoveTowardsPlayer()
    {
        animator.SetBool("isMoving", true);
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }

    void Attack()
    {
        animator.SetBool("isMoving", false);

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;

            // ���� �ִϸ��̼� Ʈ����
            animator.SetTrigger("attack");

            // ���⿡�� �÷��̾�� �������� �ִ� ������ ����
            Debug.Log("Boss attacks!");
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Boss took damage! Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("die");
        Debug.Log("Boss defeated!");
        // ���� �� �ൿ
        Destroy(gameObject, 2f);
    }
}
