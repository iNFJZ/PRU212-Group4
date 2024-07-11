using UnityEngine;

public class MeeleAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = false;
    private float timer = 0f;
    private float attackTime = 0.25f;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;

    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
        if(attacking)
        {
            timer += Time.deltaTime;
            if(timer >= attackTime)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }
    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
