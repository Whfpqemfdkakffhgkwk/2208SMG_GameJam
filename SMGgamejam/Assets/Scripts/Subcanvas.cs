using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subcanvas : MonoBehaviour
{
    [SerializeField]
    CanvasGroup canvasGroup;

    public void Open()
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public void Close()
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}
