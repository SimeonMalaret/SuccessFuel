using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float starTime;
    // Start is called before the first frame update
    void Start()
    {
        starTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currenTime = Time.time - starTime;

        string minutes = ((int)currenTime / 60).ToString();
        string seconds = (currenTime % 60).ToString("f1");
        timerText.text = minutes + ":" + seconds;
    }
}
