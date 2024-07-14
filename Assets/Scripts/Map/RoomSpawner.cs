using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    [SerializeField]
    public int openingDirection;
    private MapTemplate map;
    private int rand, max;
    private bool spawn = false;
    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.FindGameObjectWithTag("Rooms").GetComponent<MapTemplate>();
        max = 6;
        Invoke("Spawn", 0.2f);
    }
    // 1 need bottom door
    // 2 need top door
    // 3 need left door
    // 4 need right door
    // Update is called once per frame
    private void Update()
    {

    }
    void Spawn()
    {
        var maps = GameObject.FindGameObjectsWithTag("Map");
        if (maps.Length >= 10)
        {
            max = 0;
        }
        if (!spawn)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, max);
                Instantiate(map.Bottom[rand], transform.position, map.Bottom[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, max);
                Instantiate(map.Top[rand], transform.position, map.Top[rand].transform.rotation);

            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, max);
                Instantiate(map.Left[rand], transform.position, map.Left[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, max);
                Instantiate(map.Right[rand], transform.position, map.Right[rand].transform.rotation);
            }
            spawn = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            if (!spawn && !collision.GetComponent<RoomSpawner>().spawn)
            {
                Instantiate(map.Block, transform.position, map.Block.transform.rotation);
            }
            collision.GetComponent<RoomSpawner>().spawn = true;
        }
        spawn = true;
    }
}
