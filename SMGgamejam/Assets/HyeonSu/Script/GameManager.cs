using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    Text TimeText;

    [SerializeField]
    GameObject ClearWindow;

    [SerializeField]
    GameObject UIObj;

    [SerializeField]
    GameObject ClearScene;

    [SerializeField]
    GameObject OverScene;

    float timeLimit = 120;
    public float currentTime;

    private void Start()
    {
        if (PlayerPrefs.GetInt("FirstStart") != 1)
        {
            PlayerPrefs.SetInt("FirstStart", 1);
            PlayerPrefs.SetFloat("BestRecord", 100000);
        }
    }

    private void Update()
    {
        TimeProgress();
    }

    void TimeProgress()
    {
        if (TimeText != null)
        {
            TimeText.text = "제한시간: " + TimeSpan.FromSeconds(currentTime).ToString("mm':'ss") + " / 02:00";
        }

        currentTime += Time.deltaTime;

        if (currentTime >= timeLimit)
        {
            timeLimit = 100000000000000;
            GameOver();
        }
    }

    public void GameOver()
    {
        GameEnd(false);
        Time.timeScale = 0;
        SoundManager.Instance.PlayGameOver();
    }

    public void GameClear()
    {
        Instantiate(ClearWindow, UIObj.transform);
        Time.timeScale = 0;
        SoundManager.Instance.PlayGoalIn();
    }

    //클리어 true, 오버 false
    public void GameEnd(bool Clear)
    {
        if (Clear)
            ClearScene.SetActive(true);
        else
            OverScene.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
    }

    public void GoMain()
    {
        SceneManager.LoadScene("Splash");
        Time.timeScale = 1;
    }

    public IEnumerator SpeedUp()
    {
        Player.Instance.moveSpeed = 130;
        yield return new WaitForSeconds(10);
        Player.Instance.moveSpeed = 100;
    }

    public IEnumerator SpeedDown()
    {
        Player.Instance.moveSpeed = 80;
        yield return new WaitForSeconds(10);
        Player.Instance.moveSpeed = 100;
    }

    public IEnumerator UnboxingSpeedUp()
    {
        Player.Instance.unboxingProgressSpeed = 3;
        yield return new WaitForSeconds(15);
        Player.Instance.unboxingProgressSpeed = 2;
    }

    public IEnumerator UnboxingSpeedDown()
    {
        Player.Instance.unboxingProgressSpeed = 1;
        yield return new WaitForSeconds(15);
        Player.Instance.unboxingProgressSpeed = 2;
    }

    public IEnumerator BoostOn()
    {
        Player player = Player.Instance;
        player.transform.DOMoveX(player.transform.position.x + 20, 1.5f).SetEase(Ease.Linear);
        player.Boost = true;
        yield return new WaitForSeconds(1.5f);
        player.Boost = false;
        Debug.Log("Off");
    }

    public void QuitMain()
    {
        ConfirmPopup.Instance.Open("첫 화면으로 돌아가시겠습니까?", () => { SceneManager.LoadScene("Splash"); },
            () => { ConfirmPopup.Instance.Close(); });
    }
}