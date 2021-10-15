using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    public static bool isGameStart=false;
    public Text startTimerText;
    public int countDownTime=3;
    void Start()
    {
        isGameStart = false;
        StartCoroutine("CountDownTimer");
    }

   public IEnumerator CountDownTimer()
   {
        startTimerText.gameObject.SetActive(true);
        while (countDownTime > 0)
        {
            startTimerText.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }
        startTimerText.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        isGameStart = true;
        countDownTime = 3;
        startTimerText.gameObject.SetActive(false);
    }
}
