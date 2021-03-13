using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bandit : MonoBehaviour
{
    public int maxHealth=100;
    int currentHealth;
    public float lookRadius =25f;
    public float attackRadius =7f;
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;
    
    NavMeshAgent agent;
    GameObject target;
    CharacterController controller;
    Animator anim;
    
    private void Start(){
        currentHealth=maxHealth;
        anim=GetComponent<Animator>();
        agent=GetComponent<NavMeshAgent>();
        target=GameObject.FindGameObjectWithTag("Player");
    }
    public void TakeDamage(int damage){
        currentHealth-=damage;
        anim.SetTrigger("Hurt");
        if(currentHealth<=0){
            Death();
        }
    }
    void Death(){
        anim.SetBool("isDead",true);
        this.enabled=false;
        GetComponent<Collider>().enabled=false;
        GetComponent<NavMeshAgent>().enabled=false;
    }
    private void Update(){
        float distance = Vector3.Distance(target.transform.position, transform.position);
        float attackdistance = Vector3.Distance(target.transform.position, transform.position);
        if(distance <=lookRadius && distance>attackRadius){
             ChasePlayer();
        }else if(distance <=lookRadius && attackdistance<=attackRadius){
             AttackPlayer();
        }else{
             Patrolling();
        }
    }
    private void ChasePlayer(){
         //anim.SetBool("Draw_Sword",true);
         anim.SetFloat("Bandit_Speed",0.5f,0.1f,Time.deltaTime);
         agent.SetDestination(target.transform.position);
    }
    private void Patrolling(){
       // anim.SetBool("Draw_Sword",false);
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            anim.SetFloat("Bandit_Speed",1f,0.1f,Time.deltaTime);
            agent.SetDestination(walkPoint);

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
        anim.SetFloat("Bandit_Speed",0f,0.1f,Time.deltaTime);
        anim.SetTrigger("Attack");
        agent.SetDestination(transform.position);
        transform.LookAt(target.transform);

    }
    
}
