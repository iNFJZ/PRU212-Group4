using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    private float currentHealth;
    private Animator animator;
    private bool isDead = false;
    private MoveAndChase moveAndChase; // Reference to MoveAndChase script

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = health;
        moveAndChase = GetComponent<MoveAndChase>(); // Get the MoveAndChase component
    }

    void Update()
    {
        if (health < currentHealth)
        {
            currentHealth = health;
            animator.SetTrigger("DamageTaken");
        }

        if (health <= 0 && !isDead)
        {
            isDead = true;
            animator.SetBool("isDead", true);
            Destroy(gameObject);
        }
    }
}
