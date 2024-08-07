using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterNewRoom : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemy;
    private PolygonCollider2D[] boxCollider;
    private bool enter = false;
    private Vector3 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponents<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            var aliveEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            if (aliveEnemy == null || aliveEnemy.Length == 0)
            {
                OnDisable();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("hit");
            foreach (var item in boxCollider)
            {
                item.isTrigger = false;
            }
            SpawnEnemy(3, 5);
            enter = true;
        }
    }
    void SpawnEnemy(int min, int max)
    {
        Debug.Log("spawn");
        int count = Random.Range(min, max);
        int rand;
        for (int i = 0; i < count; i++)
        {
            spawnPoint = new Vector3(
                transform.parent.position.x + Random.Range(-2f, 2f)
                , transform.parent.position.y + Random.Range(-2f, 2f)
                , transform.parent.position.z);
            rand = Random.Range(0, enemy.Length);
            Instantiate(enemy[rand], spawnPoint, Quaternion.identity);
        }
        Debug.Log("spawn " + count);
    }
    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
