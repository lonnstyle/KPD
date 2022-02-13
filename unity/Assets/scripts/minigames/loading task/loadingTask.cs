using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using TMPro;

public class loadingTask : MonoBehaviour
{
    public GameObject bar;
    public int LoadingTime;
    public TMP_Text timerText;
    public float timer = 0.0f;
    public bool istimer = false;
    // Start is called before the first frame update
    void Start()
    {
        LoadingTime = (Random.Range(14, 20));
    }
    // Update is called once per frame
    void Update()
    {
        if (istimer)
        {
            timer += Time.deltaTime;
            DisplayTime();
        }
        if (Mathf.Floor(timer) == LoadingTime)
        {
            istimer = false;
            main.Instance.SwitchChange(1);
        }
    }
    public void AnimateBar()
    {
        istimer = true;
        LeanTween.scaleX(bar, 14, LoadingTime);
        //the length the bar scale up right near to the background is 14 
    }
    void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timerText.text = string.Format("Loading time: {0:0}:{1:00}", minutes, seconds);
    }

}
