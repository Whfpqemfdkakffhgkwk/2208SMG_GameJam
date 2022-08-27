using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //1 �̼�����, 2 �̼Ӱ���, 3 �����ӵ�����, 4 �����ӵ�����, 5 �ν�Ʈ
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
                text.text = "�̵� �ӵ� ���";
                break;
            case 2:
                text.text = "�̵� �ӵ� ����";
                break;
            case 3:
                text.text = "���� ���� �ӵ� ����";
                break;
            case 4:
                text.text = "���� ���� �ӵ� ����";
                break;
            case 5:
                text.text = "�ν�Ʈ";
                break;
        }
    }
}
