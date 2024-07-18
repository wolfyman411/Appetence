using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float countDownSeconds = 60f;
    public TMP_Text countDownDisplay;

    private float _countDOwnTime
    {
        get { return countDownSeconds; }
        set { countDownSeconds = value; }
    }
    private bool _countStart;
    // Start is called before the first frame update
    void Start()
    {
        CountStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (_countStart)
        {
            if (_countDOwnTime > 0)
            {
                _countDOwnTime -= Time.deltaTime;
                TimeUIUpdate(_countDOwnTime);
            }
            else
            {
                Debug.Log("Time has run out!");
                _countDOwnTime = 0;
                CountStop();
            }
        }
    }

    public void CountStart()
    {
        _countDOwnTime = countDownSeconds;
        _countStart = true;
    }

    public void CountStop()
    {
        _countStart = false;
    }

    public void TimeUIUpdate(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        countDownDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
