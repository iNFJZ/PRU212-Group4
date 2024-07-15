using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndChase : MonoBehaviour
{
    public float moveDistance = 5.0f; // Khoảng cách di chuyển
    public float moveSpeed = 2.0f; // Tốc độ di chuyển
    public float chaseRange = 20.0f; // Tầm đánh để bắt đầu đuổi theo player

    private Vector3 startPos;
    private bool movingRight = true;
    private Transform player;
    private bool isDead = false; // Biến kiểm tra enemy đã chết hay chưa

    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isDead) // Chỉ đuổi nếu enemy chưa chết
        {
            if (player != null && Vector3.Distance(transform.position, player.position) <= chaseRange)
            {
                // Đuổi theo player
                ChasePlayer();
            }
            else
            {
                // Di chuyển qua lại
                Patrol();
            }
        }
        else
        {
            // Nếu enemy đã chết, có thể làm gì đó khác tại đây nếu cần thiết
        }
    }

    void Patrol()
    {
        float moveStep = moveSpeed * Time.deltaTime;

        if (movingRight)
        {
            transform.position += new Vector3(moveStep, 0, 0);
            transform.localScale = new Vector3(1, 1, 1); // Quay mặt phải

            if (transform.position.x >= startPos.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position -= new Vector3(moveStep, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1); // Quay mặt trái

            if (transform.position.x <= startPos.x)
            {
                movingRight = true;
            }
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Cập nhật hướng của enemy để đối mặt với player
        if (direction.x >= 0)
        {
            if (transform.localScale.x < 0)
            {
                transform.localScale = TurnAround(transform.localScale);
            }
        }
        else
        {
            if (transform.localScale.x > 0)
            {
                transform.localScale = TurnAround(transform.localScale);
            }
        }
    }

    Vector3 TurnAround(Vector3 scale)
    {
        return new Vector3(scale.x * -1, scale.y, scale.z);
    }

    public void SetDead()
    {
        isDead = true;
        // Ngừng đuổi và làm gì đó khi enemy chết (có thể thêm logic ở đây nếu cần)
    }
}
