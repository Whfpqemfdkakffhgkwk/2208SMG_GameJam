using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class OnlineScore : MonoBehaviour
{
    public static OnlineScore Instance;

    int rank;
    public string CachedLeaderboardStr { get; private set; }

    public int Rank => rank;
    public static int Score => (int)(PlayerPrefs.GetFloat("BestRecord", 100000) * 1000);
    public bool Valid { get; private set; }
    public List<int> ScoreList { get; } = new List<int>();
    public List<string> NicknameList { get; } = new List<string>();

    public List<string> ScoreStrList { get; private set; } = new List<string>();

    void Awake()
    {
        Instance = this;
    }
    
    IEnumerator Start()
    {
        Splash.RefreshNickname(false);
            
        var runtimeGuid = PlayerPrefs.GetString("GUID", Guid.NewGuid().ToString());
        while (Application.isPlaying)
        {
            yield return UpdateScoreCoro(runtimeGuid);
        }
    }

    IEnumerator UpdateScoreCoro(string runtimeGuid)
    {
        var live = Application.isEditor == false ||
                   string.IsNullOrEmpty(Environment.GetEnvironmentVariable("GASBANK_DEV_MACHINE"));
        var url = live
            ? "https://choin.plusalpha.top:21091/kitrush/score"
            : "http://localhost:21090/kitrush/score";
        using var uwr = UnityWebRequest.Get(url);
        uwr.SetRequestHeader("X-User-Id", runtimeGuid);
        uwr.SetRequestHeader("X-User-Nickname",
            Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(PlayerPrefs.GetString("Nickname"))));
        uwr.SetRequestHeader("X-User-Score", Score.ToString());
        //Debug.Log($"Score: {Score}, {url}");
        yield return uwr.SendWebRequest();
        if (uwr.result == UnityWebRequest.Result.Success)
        {
            Valid = true;
            //Debug.Log(runtimeGuid + " : " + uwr.downloadHandler.text);
            var arr = uwr.downloadHandler.text.Split('\t').ToList();
            ScoreList.Clear();
            NicknameList.Clear();
            if (arr.Count > 0)
            {
                int.TryParse(arr[0], out rank);
                for (var i = 1; i < arr.Count; i += 3)
                {
                    //var userId = arr[i];
                    float.TryParse(arr[i + 1], out var userScore);
                    ScoreList.Add((int)userScore);
                    NicknameList.Add(arr[i + 2]);
                }

                if (ScoreList.Count > 0)
                {
                    var playerScoreIndex = ScoreList.FindIndex(0, e => e == Score);
                    ScoreStrList = ScoreList
                        .Select(e => "<color=blue>" + TimeSpan.FromMilliseconds(e).ToString(@"mm\:ss") + "</color>")
                        .ToList();

                    if (playerScoreIndex < 0 || playerScoreIndex >= ScoreStrList.Count)
                    {
                        playerScoreIndex = ScoreStrList.Count / 2;
                    }

                    for (var i = 0; i < ScoreStrList.Count; i++)
                    {
                        var r = rank + 1 + i - playerScoreIndex;
                        ScoreStrList[i] = $"{r}. {ScoreStrList[i]} {NicknameList[i]}";
                        
                        if (i == playerScoreIndex)
                        {
                            ScoreStrList[i] = $"<color=brown>당신 ➔ {ScoreStrList[i]}</color>";
                        }
                        else
                        {
                            ScoreStrList[i] = $"<color=#F2DE81>당신 ➔ </color>{ScoreStrList[i]}";
                        }
                    }

                    CachedLeaderboardStr = string.Join("\n", ScoreStrList);
                }
                else
                {
                    CachedLeaderboardStr = string.Empty;
                }

                yield return new WaitForSecondsRealtime(1.0f);
            }
            else
            {
                Valid = false;
                yield return new WaitForSecondsRealtime(5.0f);
            }
        }
        else
        {
            Valid = false;
            yield return new WaitForSecondsRealtime(5.0f);
        }

        //Debug.Log(CachedLeaderboardStr);
    }
}