using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class DayTimeController : MonoBehaviour
{
    private const float secondsInDay = 86400f;
    public TMP_Text text;
    private float time;
    
    [SerializeField] private float gameStartTime = 7 * 3600;
    [SerializeField] private Color nightLightColor;
    [SerializeField] private AnimationCurve nightTimeCurve;
    [SerializeField] private Color dayLightColor = Color.white;
    [SerializeField] private int timeScale = 60;
    [SerializeField] private Light2D globalLight;
    private int days;

    int Hours
    {
        get { return (int)(time / 3600f); }
    }

    int Minutes
    {
        get { return (int)(time % 3600f / 60f); }
    }

    private void Awake()
    {
        time = gameStartTime;
    }

    private void Update()
    {
        time += Time.deltaTime * timeScale;
        text.text = Hours.ToString() + ":" + Minutes.ToString() + "\n Days: " + days.ToString();
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;
        if (time > secondsInDay)
        {
            NextDay();
        }
}

    private void NextDay()
    {
        time = 0;
        days += 1;
    }
} 
