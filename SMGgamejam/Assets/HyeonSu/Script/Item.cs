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
}
