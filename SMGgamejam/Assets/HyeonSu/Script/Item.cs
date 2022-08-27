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
}
