using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.Windows;

public class DatabaseManager : MonoBehaviour
{

    public string timeOfCompletion;
    public string basementCognitiveValue;
    public string secondCogntiveValue;

    public CountDownTimer countDownTimer;

    [SerializeField]
    private string Base_URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSdujS3SQX8Ce4TLZeB98Z9maeLMlwxykxyIoAk6tILG9s7o8Q/formResponse";



    private void Start()
    {
       
    }

    IEnumerator Post(string TimeOfCompletion, string BasementCogntiveValue, string SecondCognitiveValue)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1963157117", TimeOfCompletion);
        form.AddField("entry.2028466310", BasementCogntiveValue);
        form.AddField("entry.1977260513", SecondCognitiveValue);

        byte[] rawData = form.data;
        WWW www = new WWW(Base_URL, rawData);
        yield return www;

    
    }

    // Update is called once per frame
   public void Send()
    {
        timeOfCompletion = countDownTimer.GetComponent<CountDownTimer>().timerText1.text;
        basementCognitiveValue = countDownTimer.GetComponent<CountDownTimer>().cognitiveValues[0];
        secondCogntiveValue = countDownTimer.GetComponent<CountDownTimer>().cognitiveValues[1];

        StartCoroutine(Post(timeOfCompletion,basementCognitiveValue, secondCogntiveValue));
    }
}
