using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Environement : MonoBehaviour
{

    public int secondsInOneDay = 60;
    private float timeOfDay = 0;
    public Text timeText;
    public Text momentText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        timeText.text = GetTimeOfDay();
        momentText.text = GetMomentOfDay();
    }

    void UpdateTime()
    {
        timeOfDay += Time.deltaTime / secondsInOneDay;
        if (timeOfDay >= 1)
            timeOfDay = 0;
    }

    public string GetTimeOfDay()
    {
        string time = "";
        float hour = timeOfDay * 24;

        time += (int)hour + "h";

        return time;
    }

    public string GetMomentOfDay()
    {
        string moment = "";
        float hour = timeOfDay * 24;

        if (hour >= 6 && hour < 12)
            moment = "Morning";
        else if (hour >= 12 && hour < 18)
            moment = "Afternoon";
        else if (hour >= 18 && hour < 24)
            moment = "Evening";
        else if (hour >= 0 && hour < 6)
            moment = "Night";

        return moment;
    }
}
