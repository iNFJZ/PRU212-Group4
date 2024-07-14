using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Player, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint") || collision.CompareTag("Map"))
        {
            Destroy(collision.gameObject);
        }
    }

}
