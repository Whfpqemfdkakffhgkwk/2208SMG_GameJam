using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //1 �̼�����, 2 �̼Ӱ���, 3 �����ӵ�����, 4 �����ӵ�����, 5 �ν�Ʈ
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
