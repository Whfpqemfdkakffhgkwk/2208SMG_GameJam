using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemSlider : MonoBehaviour
{
    public float currentTime;
    private void Update()
    {
        if (Player.Instance.itemCheck)
        {
            currentTime += Time.deltaTime;
            gameObject.GetComponent<Slider>().value = currentTime / GameManager.Instance.ItemDuration;
        }
        //else
        //{
        //    gameObject.SetActive(false);
        //}
    }
}
