using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        MovePlayer();
        FlipPlayer();
    }

    void MovePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;
    }

    void FlipPlayer()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x >= transform.position.x)
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
}
