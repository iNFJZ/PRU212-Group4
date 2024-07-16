using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    private Animator animator;

    private bool isDead;
    public GameManagerScript gameManager;
    public TimeManager timeManager;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0 && !isDead)
        {
            isDead = true;
            animator.SetBool("IsDead", true);
            Time.timeScale = 0;
            gameManager.gameOver();
            timeManager.PlayerDead();
        }
    }
}