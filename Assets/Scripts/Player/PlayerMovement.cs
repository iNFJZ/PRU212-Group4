using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {

            gameObject.transform.position = new Vector3(
                transform.position.x,
                transform.position.y + speed * Time.deltaTime,
                transform.position.z
                );
        }
        if (Input.GetKey(KeyCode.A))
        {

            gameObject.transform.position = new Vector3(
                transform.position.x - speed * Time.deltaTime,
                transform.position.y,
                transform.position.z
                );
        }
        if (Input.GetKey(KeyCode.S))
        {

            gameObject.transform.position = new Vector3(
                transform.position.x,
                transform.position.y - speed * Time.deltaTime,
                transform.position.z
                );
        }
        if (Input.GetKey(KeyCode.D))
        {

            gameObject.transform.position = new Vector3(
                transform.position.x + speed * Time.deltaTime,
                transform.position.y,
                transform.position.z
                );
        }
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (direction.x >= transform.localPosition.x)
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
        return new Vector3(
            scale.x * -1,
            scale.y,
            scale.z
        );
    }
}
