using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    [SerializeField]
    public float moveSpeed = 5f;
    [SerializeField]
    public float attackRange = 3f;
    [SerializeField]
    private bool isAttacking = false; 
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && !isAttacking)
        {
            AttackPlayer();
        }
        else
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        transform.LookAt(player);
    }

    void AttackPlayer()
    {
        isAttacking = true;

        Debug.Log("Enemy is attacking!");
        Invoke("ResumeMoving", 1f);
    }

    void ResumeMoving()
    {
        isAttacking = false;
    }
}
