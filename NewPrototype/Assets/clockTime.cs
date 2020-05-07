using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clockTime : MonoBehaviour
{

    public Text time;
    private const float realSecondsPerInGameDay = 1500f;
    private float day;
    private float hoursPerDay = 24f;


    // Update is called once per frame
    void Update()
    {
        day += Time.deltaTime / realSecondsPerInGameDay;
        float dayNormalized = day % 1f;

        string hourString = Mathf.Floor(dayNormalized * 24f).ToString("00");
        string minuteString = Mathf.Floor(((dayNormalized * hoursPerDay) % 1f) * 60f).ToString("00");
        time.text = hourString + ":" + minuteString;
    }
}
