using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TokenInstance : MonoBehaviour
{
    void OnPlayerEnter(PlayerController player)
    {
        RemoveToken(player);
        ScoreManager.instance.AddPoint();
    }

    void Awake()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void RemoveToken(PlayerController player)
    {

    }


}
