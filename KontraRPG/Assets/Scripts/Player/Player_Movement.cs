using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar;


    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float runSpeed = 7;

    [SerializeField] private Transform AttackPoint;
    [SerializeField] private float attackRate = 0.5f;
    [SerializeField] private float nextAttackTime = 0f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private int attackDamage = 40;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    [SerializeField] private CharacterController controller;

    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeHealthDamage(20);
        }
    }

    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;
        }

        controller.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        Collider[] hitEnemies = Physics.OverlapSphere(AttackPoint.position, attackRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Bandit>().TakeDamage(attackDamage);
            enemy.GetComponent<Witch>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

    //health bar

    void TakeHealthDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    //healtbar end
}