using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImageFlipper : MonoBehaviour
{
    int index;
    
    [SerializeField]
    Sprite[] spriteList;

    [SerializeField]
    SpriteRenderer targetRenderer;

    void Awake()
    {
        
    }

    public void Flip()
    {
        if (spriteList.Length == 0)
        {
            Debug.LogError("Empty sprite list");
            return;
        }

        if (targetRenderer == null)
        {
            Debug.LogError("Target renderer null");
            return;
        }
        
        targetRenderer.sprite = spriteList[index];
        index = (index + 1) % spriteList.Length;
    }
}
