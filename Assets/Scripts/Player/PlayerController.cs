using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isAttacking;
    private bool isShooting;
    public float attackDelay = 0.5f; // Thời gian delay giữa các lần tấn công
    public float shootDelay = 0.5f;  // Thời gian delay giữa các lần bắn
    private bool canAttack = true;
    private bool canShoot = true;
    public float moveSpeed = 5f; // Tốc độ di chuyển của player
    private bool facingRight = true; // Biến để kiểm tra hướng của player
    private bool isDead = false; // Biến để kiểm tra trạng thái chết
    private float animationDelay = 0.1f; // Thời gian delay giữa các animation
    private bool isRolling = false;
    public float damage;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    public SoundControl soundControl;

    private void Awake()
    {
        soundControl = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundControl>();
    }

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Sử dụng Rigidbody2D cho 2D game
    }

    void Update()
    {
        if (isDead) return; // Nếu player chết, không thực hiện các hành động khác

        HandleMovement();
        HandleCrouch();
        HandleAttack();
        HandleRoll();

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("IsShooting", true);
            soundControl.PlaySFX(soundControl.bullet);
        }
        else
        {
            animator.SetBool("IsShooting", false);
        }
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        rb.velocity = movement;

        if (moveX != 0 || moveY != 0)
        {
            animator.SetBool("IsMoving", true);
            if (moveX > 0 && !facingRight)
            {
                Flip();
            }
            else if (moveX < 0 && facingRight)
            {
                Flip();
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    void HandleAttack()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("IsAttacking", true);
            soundControl.PlaySFX(soundControl.attack);
        }
    }

    public void endAttack()
    {
        animator.SetBool("IsAttacking", false);
    }

    public void attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("Hit enemy");
            enemyGameObject.GetComponent<EnemyHealth>().health -= damage;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }

    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", true);
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
                rb.velocity = movement * 0.5f;
                Debug.Log("Crouch Movement: " + rb.velocity);
            }
        }
        else
        {
            animator.SetBool("IsCrouching", false);
        }
    }

    void HandleRoll()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            StartCoroutine(RollCoroutine());
        }
    }

    IEnumerator RollCoroutine()
    {
        isRolling = true;
        animator.SetBool("IsRolling", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("IsRolling", false);
        yield return new WaitForSeconds(animationDelay);
        isRolling = false;
    }

    public void Die()
    {
        isDead = true;
        animator.SetBool("IsDead", true);
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        soundControl.PlaySFX(soundControl.death);
        StartCoroutine(FreezeGameAfterDelay(1f));
    }

    IEnumerator FreezeGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 0;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
