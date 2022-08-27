using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameClear : MonoBehaviour
{
    [SerializeField] Text ClearText;
    [SerializeField] Text HighText;
    [SerializeField] GameObject HighScore;

    float gameClearTime;
    private void Start()
    {
        gameClearTime = GameManager.Instance.currentTime;

        if(PlayerPrefs.GetFloat("BestRecord") > gameClearTime)
        {
            PlayerPrefs.SetFloat("BestRecord", gameClearTime);
            HighScore.SetActive(true);
        }

        ClearText.text = "Game Clear Time : " + gameClearTime.ToString();
        HighText.text = "High Time : " + PlayerPrefs.GetFloat("BestRecord");
    }
}
