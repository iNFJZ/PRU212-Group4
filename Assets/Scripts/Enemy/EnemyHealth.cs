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
            moveAndChase.SetDead(); // Call SetDead() in MoveAndChase script
            StartCoroutine(HandleDeath());
        }
    }

    private IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(1f); // Wait for 1 second

        Destroy(gameObject); // Destroy the enemy game object
    }
}
