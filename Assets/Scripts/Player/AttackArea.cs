using TMPro;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private PlayerStat stats;
    private float dmg;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponentInParent<PlayerStat>();
        dmg = stats.Damage();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if (collision.GetComponent<PlayerStat>() != null)
            {
                PlayerStat subStats = collision.GetComponent<PlayerStat>();
                subStats.HealthUpdate(-dmg);
            }
        }
    }
}
