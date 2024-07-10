using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float moveDistance = 5.0f; // Khoảng cách di chuyển
    public float moveSpeed = 2.0f; // Tốc độ di chuyển

    private Vector3 startPos;
    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
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
}
