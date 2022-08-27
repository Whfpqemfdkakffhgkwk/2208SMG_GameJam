using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{
    [SerializeField] Text TimeText;
    [SerializeField] GameObject ClearWindow;
    [SerializeField] GameObject UIObj;

    float timeLimit = 120;
    public float currentTime;
    private void Update()
    {
        TimeProgress();
    }

    void TimeProgress()
    {
        TimeText.text = System.Math.Truncate(currentTime) + " / 120";
        currentTime += Time.deltaTime;
        
        if(currentTime >= timeLimit)
        {
            timeLimit = 100000000000000;
            GameOver();
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("게임오버 미완성");
    }
    public void GameClear()
    {
        Instantiate(ClearWindow, UIObj.transform);
        Time.timeScale = 0;
    }
}
