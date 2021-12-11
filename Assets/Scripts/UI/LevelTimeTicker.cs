using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class LevelTimeTicker : MonoBehaviour
{
    // Start is called before the first frame update
    float currentTime = 0f;
    private bool isRunning = false;
    [SerializeField] TextMeshProUGUI CurrentTimeText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning){
            currentTime += 1*Time.deltaTime;  
            int currentLvl = SceneManager.GetActiveScene().buildIndex-1;
            ScoresModel.SetTime(currentLvl, currentTime.ToString("0"));
            DateTime date1 = new DateTime();
            date1 = date1.AddSeconds(currentTime);
            CurrentTimeText.text = date1.ToString("mm:ss");
            CurrentTimeText.color = new Color32(255, 191 ,0, 255);
        }
    }

    public void StopTimer(){
        isRunning = false;
    }

    public void StartTimer(){
        isRunning = true;
    }


}
