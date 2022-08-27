using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameWin : MonoBehaviour
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

        ClearText.text = gameClearTime.ToString();
        HighText.text = PlayerPrefs.GetFloat("BestRecord").ToString();
    }

    public void Next()
    {
        gameObject.SetActive(false);
        GameManager.Instance.GameEnd(true);
    }
}
