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
        if (TimeText != null)
        {
            TimeText.text = System.Math.Truncate(currentTime) + " / 120";
        }

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




    public IEnumerator SpeedUp()
    {
        Player.Instance.moveSpeed = 120;
        yield return new WaitForSeconds(10);
        Player.Instance.moveSpeed = 80;
    }
    public IEnumerator SpeedDown()
    {
        Player.Instance.moveSpeed = 30;
        yield return new WaitForSeconds(10);
        Player.Instance.moveSpeed = 80;
    }
    public IEnumerator UnboxingSpeedUp()
    {
        Player.Instance.unboxingProgressSpeed = 3;
        yield return new WaitForSeconds(15);
        Player.Instance.moveSpeed = 2;
    }
    public IEnumerator UnboxingSpeedDown()
    {
        Player.Instance.unboxingProgressSpeed = 1;
        yield return new WaitForSeconds(15);
        Player.Instance.moveSpeed = 2;
    }
}
