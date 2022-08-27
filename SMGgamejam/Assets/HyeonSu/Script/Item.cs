using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //1 이속증가, 2 이속감소, 3 개봉속도증가, 4 개봉속도감소, 5 부스트
    public int ItemCase;

    [SerializeField] private Sprite[] sprites;
    private void Awake()
    {
        ItemCase = Random.Range(1, 6);
        GetComponent<SpriteRenderer>().sprite = sprites[ItemCase - 1];
    }
    public void ItemEffect()
    {
        switch(ItemCase)
        {
            case 1:
                StartCoroutine(GameManager.Instance.SpeedUp());
                Debug.Log(ItemCase);
                break;
            case 2:
                StartCoroutine(GameManager.Instance.SpeedDown());
                Debug.Log(ItemCase);
                break;
            case 3:
                StartCoroutine(GameManager.Instance.UnboxingSpeedUp());
                Debug.Log(ItemCase);
                break;
            case 4:
                StartCoroutine(GameManager.Instance.UnboxingSpeedDown());
                Debug.Log(ItemCase);
                break;
            case 5:
                //StartCoroutine(SpeedUp());
                Debug.Log(ItemCase);
                break;
        }
    }
}
