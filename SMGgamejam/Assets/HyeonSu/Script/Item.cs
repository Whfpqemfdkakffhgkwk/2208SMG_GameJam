using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //1 이속증가, 2 이속감소, 3 개봉속도증가, 4 개봉속도감소, 5 부스트
    public int ItemCase;

    [SerializeField] private Sprite[] sprites;
    [SerializeField] private TextMesh text;
    private void Awake()
    {
        ItemCase = Random.Range(1, 6);
        TextWrite();
        GetComponent<SpriteRenderer>().sprite = sprites[ItemCase - 1];
    }

    void TextWrite()
    {
        switch(ItemCase)
        {
            case 1:
                text.text = "이동 속도 상승";
                break;
            case 2:
                text.text = "이동 속도 저하";
                break;
            case 3:
                text.text = "상자 개봉 속도 증가";
                break;
            case 4:
                text.text = "상자 개봉 속도 저하";
                break;
            case 5:
                text.text = "부스트";
                break;
        }
    }
}
