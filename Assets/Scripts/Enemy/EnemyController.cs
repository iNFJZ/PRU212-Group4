using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
   [SerializeField]
    public float speed = 3f;
    [SerializeField]
    public float attackDistance = 2f;
    [SerializeField]
    public float attackCooldown = 2f;
    [SerializeField]
    public float attackDamage = 10f;

    private Transform player;
    [SerializeField]
    private float lastAttackTime = 0f;

    public PlayerHealth playerHealth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    
        if (Vector3.Distance(transform.position, player.position) <= attackDistance)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
        }
    }

    void AttackPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
    
        float speedMultiplier = 2f;
        speed = speedMultiplier * speed;
        transform.position += direction * speed * Time.deltaTime;
        GetComponent<Animator>().SetTrigger("Attack");
    
        Invoke("ResetAttack", 0.5f);
    
        //player.GetComponent<PlayerScript>().TakeDamage(attackDamage);
    }
    
    void ResetAttack()
    {
        speed = 3f; 
        GetComponent<Animator>().ResetTrigger("Attack"); 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= attackDamage;
        }
    }
}
