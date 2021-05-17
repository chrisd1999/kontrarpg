using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hero : MonoBehaviour
{

    public float lookRadius = 100f;
    public float playerRadius = 7f;

    NavMeshAgent _agent;
    GameObject _target;
    CharacterController _controller;
    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        float distance = Vector3.Distance(_target.transform.position, transform.position);
        float attackdistance = Vector3.Distance(_target.transform.position, transform.position);
        if (distance <= lookRadius && distance > playerRadius)
        {
            ChasePlayer();
        }
        else if (distance <= lookRadius && attackdistance <= playerRadius)
        {
            StandPlayer();
        }
    }

    private void ChasePlayer()
    {
        //anim.SetBool("Draw_Sword",true);
        _anim.SetFloat("Hero_Speed", 1f, 0.1f, Time.deltaTime);
        _agent.SetDestination(_target.transform.position);
    }

    private void StandPlayer()
    {
        _anim.SetFloat("Hero_Speed", 0f, 0.1f, Time.deltaTime);
        _agent.SetDestination(transform.position);
        transform.LookAt(_target.transform);
    }

}
