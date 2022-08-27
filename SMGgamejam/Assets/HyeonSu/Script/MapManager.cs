using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    #region 구멍들
    [System.Serializable]
    public class HoleList
    {
        public GameObject[] HoleNum = new GameObject[3];
    }
    public HoleList[] HoleSection = new HoleList[8];
    #endregion
    #region 상자들
    [System.Serializable]
    public class BoxList
    {
        public GameObject[] BoxNum = new GameObject[3];
    }
    public BoxList[] BoxSection = new BoxList[6];
    #endregion
    private void Start()
    {
        for (int i = 0; i < HoleSection.Length; i++)
        {
            HoleSection[i].HoleNum[Random.Range(0, 3)].SetActive(true);
        }
        for (int i = 0; i < BoxSection.Length; i++)
        {
            BoxSection[i].BoxNum[Random.Range(0, 3)].SetActive(true);
        }
    }
}
