using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{

    [Header("Component")]
    [SerializeField] Slider slider1;
    public TextMeshProUGUI timerText1;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    [SerializeField] bool hasLimit;
    [SerializeField] float timerLimit;

    [Header("Format Settings")]
    public bool hasFormat;


    [Header("Stopwatch Current Timer")]
    [SerializeField] Slider slider2;
    [SerializeField] TextMeshProUGUI timerText2;


    float timer2 = 0f;
    bool stopTimerActive = false;
    float stopWatchTimerLimit = 4.99f;
    public float stopWatchCurrentTimer = 0f;



    public List<string> cognitiveClickValues = new List<string>();
    public List<string> cognitiveValues = new List<string>();

    public string basementCognitiveValue;
    public string secondCogntiveValue;
    public bool hasBasementValue = false;
    public bool hasSecondValue = false;

    void Start()
    {

        timer2 = 0;

        if (basementCognitiveValue == "")
        {
            cognitiveValues[0] = ("00:05:00");
        }


        if (secondCogntiveValue == "")
        {
            cognitiveValues[1] = ("00:05:00");
        }


    }



    public void Update()
    {

        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        if (hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetTimerText();
            enabled = false;
        }

        SetTimerText();

        StopWatchTimer();
    }

    private void SetTimerText()
    {
        float minutes = (int)(currentTime / 60) % 60;
        float seconds = (int)(currentTime % 60);
        timerText1.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }





    #region StopWatchTimer
    public void StopWatchTimer()
    {
        stopWatchCurrentTimer += Time.deltaTime;



        float minutes = (int)(stopWatchCurrentTimer / 60) % 60;
        float seconds = (int)(stopWatchCurrentTimer % 60);

        if ((minutes == 0 && seconds == 5) || (minutes == 0 && seconds == 20))
        {

            stopTimerActive = true;


        }

        if (timer2 < stopWatchTimerLimit)
        {

            Timer2();

        }

        else if (timer2 >= stopWatchTimerLimit)
        {
            stopTimerActive = false;
            slider2.value = 0;
            timer2 = 0;
            timerText2.text = "00:00:00";
            Debug.Log("00:05:00");


        }

        if ((minutes == 0 && seconds == 5))
        {

            hasBasementValue = true;
            hasSecondValue = false;

        }

        if ((minutes == 0 && seconds == 20))
        {

            hasSecondValue = true;
            hasBasementValue = false;

        }


    }

    private void Timer2()
    {

        if (stopTimerActive)
        {

            timer2 += Time.deltaTime;
            slider2.value = timer2 / stopWatchTimerLimit;

            float seconds = (timer2 % 60);
            float minutes = (int)(timer2 / 60) % 60;

            string secondsString = seconds.ToString("F3");

            timerText2.text = minutes.ToString("00") + ":" + secondsString;

        }

    }

    public void ResetTimer()
    {
        if (stopTimerActive)
        {
            StartCoroutine(ResetText());
        }



    }

    IEnumerator ResetText()
    {

        cognitiveClickValues.Add(timerText2.text);


        float minutes = (int)(stopWatchCurrentTimer / 60) % 60;
        float seconds = (int)(stopWatchCurrentTimer % 60);

        if (hasBasementValue&&!hasSecondValue)
        {

            basementCognitiveValue = cognitiveClickValues[0];
            cognitiveValues[0] = basementCognitiveValue;

            hasBasementValue = false;

        }

        if (hasSecondValue && !hasBasementValue)
        {

            secondCogntiveValue = cognitiveClickValues[0];

            cognitiveValues[1] = secondCogntiveValue;
            hasSecondValue = false;

        }
        cognitiveClickValues.Clear();

        yield return new WaitForSeconds(0.5f);
        stopTimerActive = false;
        slider2.value = 0;
        timer2 = 0;
        timerText2.text = "00:00:00";
    }

    #endregion 
}
