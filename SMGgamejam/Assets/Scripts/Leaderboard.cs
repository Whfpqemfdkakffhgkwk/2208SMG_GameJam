using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    Text text;
    
    IEnumerator Start()
    {
        while (Application.isPlaying)
        {
            text.text = OnlineScore.Instance.CachedLeaderboardStr;
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
