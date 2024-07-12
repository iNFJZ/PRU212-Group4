using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
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

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Sử dụng Rigidbody2D cho 2D game
        Debug.Log("PlayerController started");
    }

    void Update()
    {
        if (isDead) return; // Nếu player chết, không thực hiện các hành động khác

        HandleMovement();
        HandleAttack();
        HandleShoot();
        HandleCrouch();
        HandleRoll();
    }

    void HandleMovement()
    {
        if (isRolling) return; // Nếu đang rolling, không di chuyển

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Debug.Log("moveX: " + moveX + ", moveY: " + moveY); // Kiểm tra giá trị đầu vào

        Vector2 movement = new Vector2(moveX * moveSpeed, moveY * moveSpeed);
        rb.velocity = movement;
        Debug.Log("rb.velocity: " + rb.velocity);

        if (moveX != 0 || moveY != 0)
        {
            animator.SetBool("IsMoving", true);
            Debug.Log("IsMoving set to true");
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
            Debug.Log("IsMoving set to false");
        }
    }

    void HandleAttack()
    {
        if (Input.GetMouseButton(0) && canAttack)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    void HandleShoot()
    {
        if (Input.GetMouseButton(1) && canShoot)
        {
            StartCoroutine(ShootCoroutine());
        }
    }

    IEnumerator AttackCoroutine()
    {
        canAttack = false;
        animator.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(attackDelay);
        animator.SetBool("IsAttacking", false);
        yield return new WaitForSeconds(animationDelay); // Delay giữa các animation
        canAttack = true;
    }

    IEnumerator ShootCoroutine()
    {
        canShoot = false;
        animator.SetBool("IsShooting", true);
        yield return new WaitForSeconds(shootDelay);
        animator.SetBool("IsShooting", false);
        yield return new WaitForSeconds(animationDelay); // Delay giữa các animation
        canShoot = true;
    }

    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", true);
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
                rb.velocity = movement * 0.5f; // Giảm tốc độ khi cúi
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
        yield return new WaitForSeconds(0.5f); // Thời gian của animation roll
        animator.SetBool("IsRolling", false);
        yield return new WaitForSeconds(animationDelay); // Delay giữa các animation
        isRolling = false;
    }

    public void Die()
    {
        isDead = true;
        animator.SetBool("IsDead", true);
        // Thêm các hành động khác khi player chết (ví dụ: disable di chuyển)
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
