using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float starTime;
    private float freezeTime;
    private float currenTime;
    // Start is called before the first frame update
    void Start()
    {
        starTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager._instance.pauseTimer == false)
        {
            currenTime = Time.time - starTime;
        } else
        {
            freezeTime = currenTime;
        }
        string minutes = ((int)currenTime / 60).ToString();
        string seconds = (currenTime % 60).ToString("f1");
        timerText.text = minutes + ":" + seconds;
    }
}
