using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    [SerializeField]
    float baseSpeed;

    [SerializeField]
    float baseHp, baseDmg;

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

    }
    public float Speed()
    {
        return speed;
    }
}
