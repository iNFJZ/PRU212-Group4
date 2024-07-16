using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeManager : MonoBehaviour
{
    public Text TimerText;
    private bool isPlayerAlive = true;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerAlive)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("F0");

            TimerText.text = minutes + ":" + seconds;
        }
    }

    public void PlayerDead()
    {
        isPlayerAlive = false;
    }
}
