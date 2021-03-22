using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bandit : MonoBehaviour
{
    public int maxHealth = 100;
    int _currentHealth;
    public float lookRadius = 25f;
    public float attackRadius = 7f;
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    NavMeshAgent _agent;
    GameObject _target;
    CharacterController _controller;
    Animator _anim;

    private void Start()
    {
        _currentHealth = maxHealth;
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _anim.SetTrigger("Hurt");
        if (_currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        _anim.SetBool("isDead", true);
        this.enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
    }

    private void Update()
    {
        float distance = Vector3.Distance(_target.transform.position, transform.position);
        float attackdistance = Vector3.Distance(_target.transform.position, transform.position);
        if (distance <= lookRadius && distance > attackRadius)
        {
            ChasePlayer();
        }
        else if (distance <= lookRadius && attackdistance <= attackRadius)
        {
            AttackPlayer();
        }
        else
        {
            Patrolling();
        }
    }

    private void ChasePlayer()
    {
        //anim.SetBool("Draw_Sword",true);
        _anim.SetFloat("Bandit_Speed", 0.5f, 0.1f, Time.deltaTime);
        _agent.SetDestination(_target.transform.position);
    }

    private void Patrolling()
    {
        // anim.SetBool("Draw_Sword",false);
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            _anim.SetFloat("Bandit_Speed", 1f, 0.1f, Time.deltaTime);
        _agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f))
            walkPointSet = true;
    }

    private void AttackPlayer()
    {
        _anim.SetFloat("Bandit_Speed", 0f, 0.1f, Time.deltaTime);
        _anim.SetTrigger("Attack");
        _agent.SetDestination(transform.position);
        transform.LookAt(_target.transform);
    }
}