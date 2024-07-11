using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField]
    float baseSpeed;

    [SerializeField]
    float baseHp, baseDmg;
    [SerializeField]
    float Hp, Dmg, speed;
    // Start is called before the first frame update
    void Start()
    {
        Hp = baseHp;
        Dmg = baseDmg;
        speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public float Speed()
    {
        return speed;
    }
    public float HealthPoint()
    {
        return Hp;
    }
    public float Damage()
    {
        return Dmg;
    }
    //Update + stat
    public float SpeedUpdate(float speedChange)
    {
        speed += speedChange;
        return Speed();
    }
    public float HealthUpdate(float healUpdate)
    {
        Hp += healUpdate;
        return Speed();
    }
    public float DamageUpdate(float damageUpdate)
    {
        Dmg += damageUpdate;
        return Speed();
    }

    //update stat multiple
    public float SpeedMultiple(float speedChange)
    {
        speed *= speedChange;
        return Speed();
    }
    public float HealthMultiple(float healthChange)
    {
        Hp *= healthChange;
        return Speed();
    }
    public float DamageMultiple(float damageMultiple)
    {
        Dmg *= damageMultiple;
        return Speed();
    }

}
