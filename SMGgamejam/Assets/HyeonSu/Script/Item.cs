using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //1 �̼�����, 2 �̼Ӱ���, 3 �����ӵ�����, 4 �����ӵ�����, 5 �ν�Ʈ
    public int ItemCase;

    void ItemEffect()
    {
        switch(ItemCase)
        {
            case 1:
                StartCoroutine(SpeedUp());
                break;
            case 2:
                StartCoroutine(SpeedDown());
                break;
            case 3:
                //StartCoroutine(SpeedUp());
                break;
            case 4:
                //StartCoroutine(SpeedUp());
                break;
            case 5:
                //StartCoroutine(SpeedUp());
                break;
        }
    }

    IEnumerator SpeedUp()
    {
        Player.Instance.moveSpeed = 120;
        yield return new WaitForSeconds(10);
        Player.Instance.moveSpeed = 80;
    }
    IEnumerator SpeedDown()
    {
        Player.Instance.moveSpeed = 30;
        yield return new WaitForSeconds(10);
        Player.Instance.moveSpeed = 80;
    }
    IEnumerator UnboxingSpeedUp()
    {
        Player.Instance.unboxingProgressSpeed = 3;
        yield return new WaitForSeconds(15);
        Player.Instance.moveSpeed = 2;
    }
    IEnumerator UnboxingSpeedDown()
    {
        Player.Instance.unboxingProgressSpeed = 1;
        yield return new WaitForSeconds(15);
        Player.Instance.moveSpeed = 2;
    }
}
